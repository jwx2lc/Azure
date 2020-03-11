﻿using System;
using System.Collections.Generic;

namespace PowerBI.Data.ReportingDB
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
