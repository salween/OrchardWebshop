using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchard.Webshop.Models;

namespace Orchard.Webshop.Services
{
    public interface IShoppingCart : IDependency
    {
        IEnumerable<ShoppingCartItem> Items { get; }
        void Add(int productId, int quantity = 1);
        void Remove(int productId);
        ProductPart GetProduct(int productId);
        decimal Subtotal();
        decimal Vat();
        decimal Total();
        int ItemCount();
        void UpdateItems();
    }
}
