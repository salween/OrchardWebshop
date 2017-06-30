using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.Themes;
using Orchard.Webshop.ViewModels;

namespace Orchard.Webshop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrchardServices _services;
        private readonly IAuthenticationService _authenticationService;
        private Localizer T { get; set; }

        public CheckoutController(IOrchardServices services, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _services = services;
        }

        [Themed]
        public ActionResult SignupOrLogin()
        {
            if (_authenticationService.GetAuthenticatedUser() != null)
                return RedirectToAction("SelectAddress");

            return new ShapeResult(this, _services.New.Checkout_SignupOrLogin());
        }

        [HttpPost]
        public ActionResult Signup(SignupViewModel signup)
        {
            if (!ModelState.IsValid)
                return new ShapeResult(this, _services.New.Checkout_Signup(Signup: signup));

            // TODO: Create a new account for the customer
            return RedirectToAction("SelectAddress");
        }

        [Themed]
        public ActionResult Login()
        {
            var shape = _services.New.Checkout_Login();
            return new ShapeResult(this, shape);
        }

        [Themed]
        public ActionResult SelectAddress()
        {
            var shape = _services.New.Checkout_SelectAddress();
            return new ShapeResult(this, shape);
        }

        [Themed]
        public ActionResult Summary()
        {
            var shape = _services.New.Checkout_Summary();
            return new ShapeResult(this, shape);
        }
    }
}
