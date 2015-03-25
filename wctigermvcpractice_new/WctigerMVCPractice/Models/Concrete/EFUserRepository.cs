using Models.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<User> GetUser()
        {
            return _context.Users;
        }

        public IEnumerable<User> GetUser(string userName)
        {
            return _context.Users.Where(user => user.UserName == userName);
        }

        public bool SaveUser(User user)
        {
            var existingUsers = GetUser(user.UserName);
            if (existingUsers.Any())
                return false;
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;
        }
        
    }
}
