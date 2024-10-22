using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class User
    {
        public User()
        {
            Dictionaries = new HashSet<Dictionary>();
            EditHistories = new HashSet<EditHistory>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Status { get; set; }
        public int Role { get; set; }

        public virtual Role RoleNavigation { get; set; } = null!;
        public virtual ICollection<Dictionary> Dictionaries { get; set; }
        public virtual ICollection<EditHistory> EditHistories { get; set; }
    }
}
