using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Model
{
    public class User : DataModel
    {

        public User()
        {
            Skills = new HashSet<Skill>();
            Interests = new HashSet<Interest>();
        }
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        //Navigation properties

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }

        public virtual Guid RoleId { get; set; }
    }
}
