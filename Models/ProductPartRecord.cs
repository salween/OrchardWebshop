using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchard.ContentManagement.Records;

namespace Orchard.Webshop.Models
{
    public class ProductPartRecord : ContentPartRecord
    {
        public virtual decimal Price { get; set; }
        public virtual string Sku { get; set; }
    }
}
