using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class EditHistory
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public string OldWord { get; set; } = null!;
        public string OldVietnamese { get; set; } = null!;
        public string NewWord { get; set; } = null!;
        public string NewVietnamese { get; set; } = null!;
        public DateTime EditDate { get; set; }
        public int EditBy { get; set; }

        public virtual User EditByNavigation { get; set; } = null!;
        public virtual Dictionary Word { get; set; } = null!;
    }
}
