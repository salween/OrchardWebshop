using Orchard.ContentManagement;

namespace Orchard.Webshop.Models
{
    public class AddressPart : ContentPart<AddressPartRecord>
    {
        public int CustomerId
        {
            get { return Retrieve(r => r.CustomerId); }
            set { Store(r => r.CustomerId, value); }
        }

        public string Type
        {
            get { return Retrieve(r => r.Type); }
            set { Store(r => r.Type, value); }
        }
    }
}
