using System;
using Orchard.ContentManagement.Records;

namespace Orchard.Webshop.Models
{
    public class CustomerPartRecord : ContentPartRecord
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime CreatedUtc { get; set; }
    }
}
