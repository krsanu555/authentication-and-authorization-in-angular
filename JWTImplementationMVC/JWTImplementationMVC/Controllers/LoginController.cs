using JWTImplementationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWTImplementationMVC.Controllers
{
    public class LoginController : ApiController
    { [HttpPost]
        public HttpResponseMessage Login(User user)
        {
            UserRepository userservice = new UserRepository();
                User user1 = userservice.GetUser(user.UserName, user.Password);
            if (user1 == null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User", Configuration.Formatters.JsonFormatter);
            }
            else
            {

                AuthenticationModel authentication = new AuthenticationModel();
                string token = authentication.GenerateTokenForUser(user1.UserName, user1.UserId,user1.Roles);
                return Request.CreateResponse(HttpStatusCode.OK, token, Configuration.Formatters.JsonFormatter);
            }  
        }


    }
}
