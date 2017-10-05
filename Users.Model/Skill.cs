using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Model
{
    public class Skill : DataModel
    {
        public Skill()
        {
                
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Difficulty { get; set; }

        // Navigation properties
        public virtual ICollection<User> Users { get; set; }
    }
}
