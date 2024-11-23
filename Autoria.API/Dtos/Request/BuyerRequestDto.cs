using System.ComponentModel;

namespace Autoria.API.Dtos.Request
{
    public class BuyerRequestDto
    {
        [DefaultValue("")]
        public string Username { get; set; }
        [DefaultValue("")]
        public string Name { get; set; }
        [DefaultValue("")]
        public string Surname { get; set; }
        [DefaultValue("")]
        public string Phone { get; set; }
        [DefaultValue("")]
        public string Email { get; set; }
    }
}