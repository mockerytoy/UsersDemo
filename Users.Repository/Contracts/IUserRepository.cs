using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Model;

namespace Users.Repository.Contracts
{
    public interface IUserRepository
    {

        IEnumerable<User> GetAllCustomers();

        User GetCustomerByUsername(string username);

        User GetCustomerByIdentityNumber(string identityNumber);
    }
}
