using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace introDotNetCore.Models
{
    public class RsvpModel
    {
        [Required(ErrorMessage = "E-posta boş olamaz")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen seçiminizi yapın!")]
        public bool? IsAccept { get; set; }
    }
}
