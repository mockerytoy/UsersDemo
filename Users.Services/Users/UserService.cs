using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Model;
using Users.Repository;
using Users.Repository.Repositories;
using Users.Services.Contracts;

namespace Users.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IEfRepository<User> _repository;
        public UserService(IEfRepository<User> repository)
        {
            this._repository = repository;
        }
        public User GetByEmail(string email)
        {
            return this._repository.All.SingleOrDefault(x => String.Equals(x.Email, email, StringComparison.OrdinalIgnoreCase));
        }

        public User GetByUserName(string username)
        {
            return this._repository.All.SingleOrDefault(x => String.Equals(x.UserName, username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
