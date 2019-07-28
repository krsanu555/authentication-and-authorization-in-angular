using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace JWTImplementationMVC.Models
{
    public class JWTAuthenticationFilter : AuthorizationFilterAttribute
    {
        public JWTAuthenticationFilter()
        {
            
        }
        public override void OnAuthorization(HttpActionContext filterContext)
        {

            if (!IsUserAuthorized(filterContext))
            {
                ShowAuthenticationError(filterContext);
                return;
            }
            base.OnAuthorization(filterContext);
        }
        public bool IsUserAuthorized(HttpActionContext actionContext)
        {
            var authHeader = FetchFromHeader(actionContext);  //fetch authorization token from header


            if (authHeader != null)
            {
                var auth = new AuthenticationModel();
                JwtSecurityToken userPayloadToken = auth.GenerateUserClaimFromJWT(authHeader);

                if (userPayloadToken != null)
                {

                    JWTAuthenticationIdentity identity = auth.PopulateUserIdentity(userPayloadToken);
                   var genericPrincipal = new GenericPrincipal(identity, identity.Roles);
                    Thread.CurrentPrincipal = genericPrincipal;
                    //below added
                    HttpContext.Current.User = Thread.CurrentPrincipal;
                    var authenticationIdentity = Thread.CurrentPrincipal.Identity as JWTAuthenticationIdentity;
                    if (authenticationIdentity != null && !String.IsNullOrEmpty(authenticationIdentity.UserName))
                    {
                        authenticationIdentity.UserId = identity.UserId;
                        authenticationIdentity.UserName = identity.UserName;
                        
                    }
                    return true;
                }

            }
            return false;


        }
        private string FetchFromHeader(HttpActionContext actionContext)
        {
            string requestToken = null;

            var authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null)
            {
                requestToken = authRequest.Parameter;
            }

            return requestToken;
        }

        private static void ShowAuthenticationError(HttpActionContext filterContext)
        {
         filterContext.Response =filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unable to access, Please login again");
        }

    }
}