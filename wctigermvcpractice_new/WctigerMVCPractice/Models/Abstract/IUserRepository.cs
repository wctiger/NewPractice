using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUser();

        IEnumerable<User> GetUser(string userName);

        bool SaveUser(User user);
    }
}
