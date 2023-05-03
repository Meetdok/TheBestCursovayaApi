using System;
using System.Collections.Generic;

namespace WebTheBestCursach.Models
{
    public partial class LoginPage
    {
        public LoginPage()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
