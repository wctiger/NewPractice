using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Abstract;
using Models.Entities;
using Utilities;

namespace Models.Concrete
{
    public class FormsAuthenticationProvider : IAuthentication
    {
        private IUserRepository repo = new EFUserRepository();
        public bool Authenticate(string username, string password)
        {
            User result = null;

            if (username.Equals("Admin"))
            {
                result = repo.GetUser().FirstOrDefault(user => user.UserName == username && user.Password == password);
            }
            else
            {
                Guid userGuid = repo.GetUser().FirstOrDefault(user => user.UserName == username).UserGuid;
                string guidPassword = password + userGuid.ToString();
                string sha1Password = SecurityUtility.EncryptPassword(guidPassword);
                result = repo.GetUser().FirstOrDefault(user => user.UserName == username && user.Password == sha1Password);
            }
            
            if (result == null)
                return false;
            return true;
        }

        public bool Logout()
        {
            return true;
        }
    }
}
