﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Model
{
   public class Interest : DataModel
    {
        public Interest()
        {
            Users = new HashSet<User>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<User> Users { get; set; }

    }
}
