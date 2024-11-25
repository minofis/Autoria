using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoria.API.Dtos.Request
{
    public class BuyerRequestDto
    {
        [DefaultValue("")]
        [Required(ErrorMessage = "Username name is required")]
        public string Username { get; set; }
        [DefaultValue("")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [DefaultValue("")]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        [DefaultValue("")]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
        [DefaultValue("")]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}