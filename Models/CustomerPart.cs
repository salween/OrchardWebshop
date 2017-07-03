using System;
using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.Users.Models;

namespace Orchard.Webshop.Models
{
    public class CustomerPart : ContentPart<CustomerPartRecord>
    {
        public string FirstName
        {
            get { return Retrieve(r => r.FirstName); }
            set { Store(r => r.FirstName, value); }
        }

        public string LastName
        {
            get { return Retrieve(r => r.LastName); }
            set { Store(r => r.LastName, value); }
        }

        public string Title
        {
            get { return Retrieve(r => r.Title); }
            set { Store(r => r.Title, value); }
        }

        public DateTime CreatedUtc
        {
            get { return Retrieve(r => r.CreatedUtc); }
            set { Store(r => r.CreatedUtc, value); }
        }

        public IUser User
        {
            get { return this.As<UserPart>(); }
        }
    }
}
