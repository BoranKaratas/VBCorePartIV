using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Middlewares
{
    public class HandleBrowserRequest
    {
        RequestDelegate next;
        public HandleBrowserRequest(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Amaç: eğer request IE'dan geliyorsa:
           httpContext.Items["isIE"] = httpContext.Request.Headers["User-Agent"].Any(value => value.ToLower().Contains("trident"));

            //Eğer başka bir custom middleware'ın görevi response'a müdahale etmek olsaydı:
            if (httpContext.Items["isIE"] as bool? == true)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsync("Internet explorer desteklenmiyor!");
               // await httpContext.Response.re
            }


            await next.Invoke(httpContext);
        }
    }
}
