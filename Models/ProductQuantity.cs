using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Webshop.Models
{
    public sealed class ProductQuantity
    {
        public ProductPart ProductPart { get; set; }
        public int Quantity { get; set; }
    }
}
