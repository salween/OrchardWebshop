using Orchard.UI.Resources;

namespace Orchard.Webshop
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            // Create and add a new manifest
            var manifest = builder.Add();

            manifest.DefineScript("jQuery").SetUrl("jquery-1.6.4.min.js", "jquery-1.6.4.js").SetVersion("1.6.4");

            // Define a "common" style sheet
            manifest.DefineStyle("Orchard.Webshop.Common").SetUrl("common.css");

            // Define the "shoppingcart" style sheet
            manifest.DefineStyle("Orchard.Webshop.ShoppingCart").SetUrl("shoppingcart.css").SetDependencies("Orchard.Webshop.Common");
        }
    }
}