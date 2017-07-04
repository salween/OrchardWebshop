using System.ComponentModel.DataAnnotations;

namespace Orchard.Webshop.ViewModels
{
    public class AddressViewModel
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(256)]
        public string AddressLine1 { get; set; }

        [StringLength(256)]
        public string AddressLine2 { get; set; }

        [StringLength(10)]
        public string Zipcode { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
    }
}
