﻿using Data.Models.Base;

namespace Data.Models
{
    public class User : SingleEntity
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Login { get; set; }
    }
}
