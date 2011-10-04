using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFiles.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
