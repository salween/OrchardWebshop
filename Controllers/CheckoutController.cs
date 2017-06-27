using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Orchard.Localization;
using Orchard.Mvc;
using Orchard.Themes;

namespace Orchard.Webshop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrchardServices _services;
        private Localizer T { get; set; }

        public CheckoutController(IOrchardServices services)
        {
            _services = services;
        }

        [Themed]
        public ActionResult SignupOrLogin()
        {
            return new ShapeResult(this, _services.New.Checkout_SignupOrLogin());
        }
    }
}
