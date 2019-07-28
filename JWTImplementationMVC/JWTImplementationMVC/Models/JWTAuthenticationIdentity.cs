using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace JWTImplementationMVC.Models
{
    public class JWTAuthenticationIdentity : GenericIdentity
    {

        public string UserName { get; set; }
        public int UserId { get; set; }
        public string[] Roles { get; set; }
        public JWTAuthenticationIdentity(string userName)
            : base(userName)
        {
            UserName = userName;
        }


    }
}