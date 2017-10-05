using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Repository;

namespace Users.Repository.SaveContext
{
    public class SaveContext : ISaveContext
    {
        private readonly UsersDbContext _context;

        public SaveContext(UsersDbContext context)
        {
            this._context = context;
        }

        public void SaveChanges()
        {
            this._context.SaveChanges(); ;
        }
    }
}
