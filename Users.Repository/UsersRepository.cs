using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Model;
using Users.Repository.Contracts;

namespace Users.Repository
{
    public class UsersRepository : IUserRepository
    {
        public IEnumerable<User> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public User GetCustomerByIdentityNumber(string identityNumber)
        {
            throw new NotImplementedException();
        }

        public User GetCustomerByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
