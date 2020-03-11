using System;
using System.Collections.Generic;

namespace PowerBI.Data.ReportingDB
{
    public partial class Role
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
            UserRoleReport = new HashSet<UserRoleReport>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
        public virtual ICollection<UserRoleReport> UserRoleReport { get; set; }
    }
}
