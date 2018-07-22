using Microsoft.IdentityModel.Tokens;
using One.Core.Auth.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace One.Core.Auth
{
    public class Token : IToken
    {
        private static readonly string Secret = Convert.ToBase64String(new HMACSHA256().Key);

        public static string GenerateToken(Model.Token token)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Sid, token.Id),
                        new Claim(ClaimTypes.Role, token.Role.ToString())
                    }),

                Expires = now.AddMinutes(Convert.ToInt32(60)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(stoken);
            
        }

        public bool Validation(HttpRequestMessage request, string operation)
        {
            throw new NotImplementedException();
        }
    }
}
