using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace shop.API.Security
{
    public class BasicHandler : AuthenticationHandler<BasicOption>
    {
        public BasicHandler(IOptionsMonitor<BasicOption> options, ILoggerFactory logger, UrlEncoder urlEncoder, ISystemClock clock):base(options,logger,urlEncoder, clock)
        {

        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            /*
             * 1. Request içinde aradığınız Authorization ifadesi var mı?
             * 2. Varsa doğru syntax ile yazılmış mı
             * 3. Doğru ise sizin belirttiğiniz isimde mi?
             * 4. Belirttiğiniz isimde ise her veriyi claim based auth. kullan
             */
            throw new NotImplementedException();
        }
    }
}
