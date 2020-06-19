using BDJ.Data;
using BDJ.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDJ.Services
{
    public class UserService : IUserService
    {
        private readonly BdjDbContext dbContext;
        private readonly UserManager<User> userManager;

        public UserService(BdjDbContext dbContext, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }
        
        public User Create(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public User Delete(User user)
        {
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return user;
        }

        public List<User> GetAll()
        {
            return dbContext.Users.ToList();
        }

        public User GetById(string id)
        {
            return dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool IsAdmin(User user)
        {
            string roleId = dbContext.Roles.First(r => r.Name == "Admin").Id;
            return dbContext.UserRoles.Any(ur => ur.RoleId == roleId && ur.UserId == user.Id);
        }

        public User Update(User user)
        {
            User oldUser = GetById(user.Id);
            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;
            oldUser.UserName = user.UserName;
            dbContext.Users.Update(oldUser);
            dbContext.SaveChanges();
            return user;
        }
    }
}
