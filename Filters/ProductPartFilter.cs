using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchard.Localization;
using Orchard.Projections.Descriptors.Filter;
using Orchard.Projections.Services;
using Orchard.Webshop.Models;

namespace Orchard.Webshop.Filters
{
    public class ProductPartFilter : IFilterProvider
    {
        public Localizer T { get; set; }

        public ProductPartFilter()
        {
            T = NullLocalizer.Instance;
        }

        public void Describe(DescribeFilterContext describe)
        {
            describe.For("Content")          // The category of this filter
                // Defines the actual filter (we could define multiple filters using the fluent syntax)
                .Element(
                    "ProductParts",         // Type of the element
                    T("Product Parts"),     // Name of the element
                    T("Product parts"),     // Description of the element
                    ApplyFilter,            // Delegate to a method that performs the actual filtering for this element
                    DisplayFilter           // Delegate to a method that returns a descriptive string for this element
                );
        }

        private void ApplyFilter(FilterContext context)
        {
            // Set the Query property of the context parameter to any IHqlQuery. In our case, we use a default query
            // and narrow it down by joining with the ProductPartRecord.
            context.Query = context.Query.Join(x => x.ContentPartRecord(typeof(ProductPartRecord)));
        }

        private LocalizedString DisplayFilter(FilterContext context)
        {
            return T("Content with ProductPart");
        }
    }
}
