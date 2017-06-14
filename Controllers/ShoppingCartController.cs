using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard.Mvc;
using Orchard.Themes;
using Orchard.Webshop.Models;
using Orchard.Webshop.Services;

namespace Orchard.Webshop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrchardServices _services;

        public ShoppingCartController(IShoppingCart shoppingCart, IOrchardServices services)
        {
            _shoppingCart = shoppingCart;
            _services = services;
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            // Add the specified content id to the shopping cart with a quantity of 1
            _shoppingCart.Add(id, 1);

            // Redirect the user to the Index action
            return RedirectToAction("Index");
        }

        [Themed]
        public ActionResult Index()
        {
            // Create a new shape using the "New" property of IOrchardServices
            var shape = _services.New.ShoppingCart();

            // Get a list of all product IDs from the shopping cart
            var ids = _shoppingCart.Items.Select(x => x.ProductId).ToList();

            // Load all product parts by the list of IDs
            var productParts = _services.ContentManager.GetMany<ProductPart>(ids, VersionOptions.Latest, QueryHints.Empty).ToArray();

            // Create a LINQ query that projects all items in the shopping cart into shapes
            var query = from item in _shoppingCart.Items
                        from productPart in productParts where productPart.Id == item.ProductId
                        select _services.New.ShoppingCartItem(
                            product: productPart,
                            Quantity: item.Quantity
                            );

            // Execute the LINQ query and store the results on a property of the shape
            shape.Products = query.ToList();

            // Store the grand total, sub total and VAT of the shopping cart in a property on the shape
            shape.Total = _shoppingCart.Total();
            shape.Subtotal = _shoppingCart.Subtotal();
            shape.Vat = _shoppingCart.Vat();

            // Return a ShapeResult. This is more opitmal because it can be override
            // with themes as shape alternatives
            return new ShapeResult(this, shape);
        }
    }
}
