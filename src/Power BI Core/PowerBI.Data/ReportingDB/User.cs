using System;
using System.Collections.Generic;

namespace PowerBI.Data.ReportingDB
{
    public partial class User
    {
        public User()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
