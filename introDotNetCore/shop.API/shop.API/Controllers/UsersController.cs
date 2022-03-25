using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using shop.API.Models;
using shop.Business;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLogin)
        {
            var user = userService.Validate(userLogin.UserName, userLogin.Password);
            if (user != null)
            {
                //claim ile birlikte token üretilerek client'a gönderilecek:
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.Name),
                    new Claim(ClaimTypes.Role,user.Role),
                    //new Claim(JwtRegisteredClaimNames.Email,user.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Dönülmez akşamın ufkundayız vakit çok geç!"));

                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "vakifbank.com.tr",
                    audience: "vakifbank.com.tr",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credential);
                //HttpContext.SignInAsync()
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });


            }
            return BadRequest(new { message = "Hatalı kullanıcı adı...." });
        }
    }
}
