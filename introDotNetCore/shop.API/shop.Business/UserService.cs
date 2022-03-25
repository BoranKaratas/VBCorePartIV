using shop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Business
{
    public class UserService : IUserService
    {
        private List<User> users;
        public UserService()
        {
            users = new List<User>
            {
                 new User{ Id=1, Name ="turkay", Password="123", Role="Admin"},
                 new User{ Id=2, Name ="boran", Password="123", Role="User"},

            };
        }
        public User Validate(string username, string password)
        {
            return users.Find(u => u.Name == username && u.Password == password);
        }
    }
}
