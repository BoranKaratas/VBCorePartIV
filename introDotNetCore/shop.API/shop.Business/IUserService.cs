using shop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Business
{
   public interface IUserService
    {
        User Validate(string username, string password);
        
    }
}
