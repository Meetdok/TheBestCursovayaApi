using System;
using System.Collections.Generic;

namespace WebTheBestCursach.Models
{
    public partial class User
    {
        public User()
        {
            AduccationForms = new HashSet<AduccationForm>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserLatName { get; set; }
        public int? RoleId { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Mail { get; set; }
        public int LoginId { get; set; }

        public virtual LoginPage Login { get; set; } = null!;
        public virtual Role? Role { get; set; }
        public virtual ICollection<AduccationForm> AduccationForms { get; set; }
    }
}
