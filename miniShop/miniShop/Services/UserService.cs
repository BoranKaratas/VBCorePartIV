using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Services
{
    public class UserService : IUserService
    {
        private List<User> users;
        public UserService()
        {
            users = new List<User>
            {

                new User{ Id=1, UserName="turkay", FullName="Türkay Ürkmez", Password="1234", Role="Admin", Email="abc@ddd.com"},
                new User{ Id=2, UserName="gokcen", FullName="Gökçen Türköz", Password="1234", Role="Editor", Email="abc@ddd.com"},
                new User{ Id=1, UserName="harun", FullName="Harun Uysal", Password="1234", Role="User", Email="abc@ddd.com"},

            };
        }
        public User Validate(string userName, string password)
        {
            return users.FirstOrDefault(u => u.UserName == userName && u.Password == password);

        }
    }
}
