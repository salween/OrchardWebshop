using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.Webshop.Models;

namespace Orchard.Webshop.Services
{
    public class ShoppingCart : IShoppingCart
    {
        // Gives access to current request and related data
        private readonly IWorkContextAccessor _workContextAccessor;
        // Content item manager
        private readonly IContentManager _contentManager;
        public IEnumerable<ShoppingCartItem> Items
        {
            get { return ItemsInternal.AsReadOnly(); }
        }

        private HttpContextBase HttpContext
        {
            get { return _workContextAccessor.GetContext().HttpContext; }
        }

        private List<ShoppingCartItem> ItemsInternal
        {
            get
            {
                var items = (List<ShoppingCartItem>)HttpContext.Session["ShoppingCart"];

                if (items == null)
                {
                    items = new List<ShoppingCartItem>();
                    HttpContext.Session["ShoppingCart"] = items;
                }

                return items;
            }
        }

        public ShoppingCart(IWorkContextAccessor workContextAccessor, IContentManager contentManager)
        {
            _workContextAccessor = workContextAccessor;
            _contentManager = contentManager;
        }

        public void Add(int productId, int quantity = 1)
        {
            var item = Items.SingleOrDefault(x => x.ProductId == productId);

            if (item == null)
            {
                item = new ShoppingCartItem(productId, quantity);
                ItemsInternal.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void Remove(int productId)
        {
            var item = Items.SingleOrDefault(x => x.ProductId == productId);

            if (item == null)
                return;

            ItemsInternal.Remove(item);
        }

        public ProductPart GetProduct(int productId)
        {
            return _contentManager.Get<ProductPart>(productId);
        }

        public IEnumerable<ProductQuantity> GetProducts()
        {
            // Get a list of all product IDs from the shopping cart
            var ids = Items.Select(x => x.ProductId).ToList();

            // Load all product parts by the list of IDs
            var productParts = _contentManager.GetMany<ProductPart>(ids, VersionOptions.Latest, QueryHints.Empty).ToArray();

            // Create a LINQ query that projects all items in the shopping cart into shapes
            var query = from item in Items
                        from productPart in productParts
                        where productPart.Id == item.ProductId
                        select new ProductQuantity {
                            ProductPart = productPart,
                            Quantity = item.Quantity
                        };

            return query;
        }

        public void UpdateItems()
        {
            ItemsInternal.RemoveAll(x => x.Quantity == 0);
        }

        public decimal Subtotal()
        {
            return Items.Select(x => GetProduct(x.ProductId).Price * x.Quantity).Sum();
        }

        public decimal Vat()
        {
            return Subtotal() * .19m;
        }

        public decimal Total()
        {
            return Subtotal() + Vat();
        }

        public int ItemCount()
        {
            return Items.Sum(x => x.Quantity);
        }

        private void Clear()
        {
            ItemsInternal.Clear();
            UpdateItems();
        }
    }
}
