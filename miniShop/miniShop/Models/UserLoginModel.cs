using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Models
{
    public class UserLoginModel
    {
        //Bu özelliğin burada olması tamamen mantıksız. Tembelliğimden yaptım.
        public int Id { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı zorunlu")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre zorunlu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
