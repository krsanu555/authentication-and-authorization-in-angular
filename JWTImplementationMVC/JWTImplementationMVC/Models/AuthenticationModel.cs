using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace JWTImplementationMVC.Models
{
    public class AuthenticationModel
    {
        private static string Secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";
       static byte[] key = Convert.FromBase64String(Secret);
       static SymmetricSecurityKey signingKey = new SymmetricSecurityKey(key);
        // The Method is used to generate token for user
        public string GenerateTokenForUser(string userName, int userId,string[] Roles)
        {
            var now = DateTime.UtcNow;
            var signingCredentials = new SigningCredentials(signingKey,
               SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);
            

            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Role,string.Join(",", Roles)),
                
            }, "Custom");
            
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = "http://www.example.com",
                Issuer = "self",
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Expires = DateTime.UtcNow.AddMinutes(1),
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;

        }

        /// Using the same key used for signing token, user payload is generated back
        public JwtSecurityToken GenerateUserClaimFromJWT(string authToken)
        {

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidAudiences = new string[]
                      {
                    "http://www.example.com",
                      },

                ValidIssuers = new string[]
                  {
                      "self",
                  },
                IssuerSigningKey = signingKey
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;

            try
            {

                tokenHandler.ValidateToken(authToken, tokenValidationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return null;

            }

            return validatedToken as JwtSecurityToken;

        }

        public JWTAuthenticationIdentity PopulateUserIdentity(JwtSecurityToken userPayloadToken)
        {
            string name = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "unique_name").Value;
            string userId = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "nameid").Value;
            string Roles= ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type =="role").Value;
            return new JWTAuthenticationIdentity(name) { UserId = Convert.ToInt32(userId), UserName = name,Roles=Roles.Split(',').ToArray() };

        }
    }
}
