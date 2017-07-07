using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Webshop.Models;

namespace Orchard.Webshop.Drivers
{
    public class CustomerPartDriver : ContentPartDriver<CustomerPart>
    {
        protected override string Prefix
        {
            get { return "Customer"; }
        }

        protected override DriverResult Editor(CustomerPart part, dynamic shapeHelper)
        {
            return ContentShape("Part_Customer_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/Customer", Models: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(CustomerPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}
