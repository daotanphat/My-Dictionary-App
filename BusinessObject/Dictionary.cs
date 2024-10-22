using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Dictionary
    {
        public Dictionary()
        {
            EditHistories = new HashSet<EditHistory>();
        }

        public int Id { get; set; }
        public string Word { get; set; } = null!;
        public string? Meaning { get; set; }
        public string Vietnamese { get; set; } = null!;
        public DateTime EditDate { get; set; }
        public bool IsApproved { get; set; }
        public int CreateBy { get; set; }
        public int WordType { get; set; }

        public virtual User CreateByNavigation { get; set; } = null!;
        public virtual WordType WordTypeNavigation { get; set; } = null!;
        public virtual ICollection<EditHistory> EditHistories { get; set; }
    }
}
