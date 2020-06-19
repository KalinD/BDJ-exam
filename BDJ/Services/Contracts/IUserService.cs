using BDJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDJ.Services.Contracts
{
    public interface IUserService
    {
        public User Create(User user);
        public User Delete(User user);
        public User GetById(string id);
        public List<User> GetAll();
        public User Update(User user);
        public bool IsAdmin(User user);
    }
}
