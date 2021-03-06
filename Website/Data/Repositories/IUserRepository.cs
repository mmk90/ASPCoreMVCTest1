using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Data.Repositories
{
   public interface IUserRepository
   {
       bool IsExistUserByEmail(string email);
        void AddUser(User user);
        User GetUserForLogin(string email, string password);
    }

    public class UserRepository : IUserRepository
    {
        private WebsiteDatabaseContext _context;

        public UserRepository(WebsiteDatabaseContext context)
        {
            _context = context;
        }

        public bool IsExistUserByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public User GetUserForLogin(string email, string password)
        {
            return _context.Users
                .SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }

}
