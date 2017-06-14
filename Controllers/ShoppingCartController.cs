using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Orchard.Webshop.Services;

namespace Orchard.Webshop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            // Add the specified content id to the shopping cart with a quantity of 1
            _shoppingCart.Add(id, 1);

            // Redirect the user to the Index action
            return RedirectToAction("Index");
        }
    }
}
