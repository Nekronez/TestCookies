using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCookie.Models;

namespace TestCookie.Controllers
{
    [ApiController]
    public class CookieController : ControllerBase
    {
        [HttpGet("/cookie/set")]
        public IActionResult SetCookie([FromBody] Cookie cookie)
        {
            HttpContext.Response.Cookies.Append(
                cookie.Name, 
                "test", 
                new CookieOptions
                {
                    Expires = new DateTimeOffset(DateTime.UtcNow.AddMinutes(5)),
                    HttpOnly = cookie.IsHttpOnly
                });

            return Ok();
        }

        [HttpGet("/cookie/remove")]
        public IActionResult RemoveCookie([FromBody] RemoveCookie removeCookie)
        {
            if(removeCookie.Name == null || removeCookie.Name == "")
            {
                foreach (var Cookie in Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(Cookie);
                }
            }
            else
            {
                Response.Cookies.Delete(removeCookie.Name);
            }
            return Ok();
        }
    }
}