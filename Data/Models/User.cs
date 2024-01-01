namespace Data.Models
{
    internal class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Nickname { get; set; }
    }
}
