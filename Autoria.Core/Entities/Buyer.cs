namespace Autoria.Core.Entities
{
    public class Buyer : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}