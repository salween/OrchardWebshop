using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Webshop.ViewModels
{
    public class AddressesViewModel : IValidatableObject
    {
        [UIHint("Address")]
        public AddressViewModel InvoiceAddress { get; set; }

        [UIHint("Address")]
        public AddressViewModel ShippingAddress { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var address = InvoiceAddress;

            if (string.IsNullOrWhiteSpace(address.AddressLine1))
                yield return new ValidationResult("Addressline 1 is a required field", new[] { "InvoliceAddress.AddressLine1" });

            if (string.IsNullOrWhiteSpace(address.Zipcode))
                yield return new ValidationResult("Zipcode is a required field", new[] { "InvoiceAddress.Zipcode" });

            if (string.IsNullOrWhiteSpace(address.City))
                yield return new ValidationResult("City is a required field", new[] { "InvoiceAddress.City" });

            if (string.IsNullOrWhiteSpace(address.Country))
                yield return new ValidationResult("Country is a required field", new[] { "InvoiceAddress.Country" });
        }
    }
}
