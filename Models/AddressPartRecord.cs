using Orchard.ContentManagement;

namespace Orchard.Webshop.Models
{
    public class AddressPartRecord : ContentPart
    {
        public virtual int CustomerId { get; set; }
        public virtual string Type { get; set; }
    }
}
