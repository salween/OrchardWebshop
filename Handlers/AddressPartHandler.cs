using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Webshop.Models;

namespace Orchard.Webshop.Handlers
{
    public class AddressPartHandler : ContentHandler
    {
        public AddressPartHandler(IRepository<AddressPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}
