using System.ComponentModel.DataAnnotations;

namespace Orchard.Webshop.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool CreatePersistentCookie { get; set; }
    }
}
