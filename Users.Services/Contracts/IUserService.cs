using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Model;

namespace Users.Services.Contracts
{
    public interface IUserService
    {
        User GetByEmail(string email);

        User GetByUserName(string email);
    }
}
