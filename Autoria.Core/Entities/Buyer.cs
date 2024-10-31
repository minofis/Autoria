namespace Autoria.Core.Entities
{
    public class Buyer : BaseEntity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}