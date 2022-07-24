using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace JWTTokenHW8.Services
{
    public class userServices
    {
        public List<User> users_data;

        const string ISSUER = "issuing-website-url";
        const string AUDIENCE = "target-website-url";
        const string key = "225e46a6fa5340b1a87b988e4e4326900c8bebf8668648579e91441d1158daf48eb60ad8d035492f8cc8846624eed68c2ee34e08db774af2bd94fb7b99f64ba7";

        private static readonly SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        public  userServices()
        {
            users_data = new List<User>()
            {
            new User {username= "Priyanshi" , password = "1234" ,percentage= "90%"},
            new User { username = "Ajit", password = "5678" , percentage="85%" },
            new User { username = "Vaibhav" , password="9012", percentage="80%"},
            new User {username= "Yashika" ,password= "abcd", percentage= "75%"},
            new User {username = "Kaustubh", password = "efgh", percentage="70%"},
            new User {username= "Raghu" , password ="ijkl", percentage="65%"}
            };
           
        }

        public string GenerateToken(string username, string password)
        {
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(
                issuer: ISSUER,
                audience: AUDIENCE,
                signingCredentials: credentials,
                claims: new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, username),
                    new Claim(JwtRegisteredClaimNames.AtHash, password)
                }
            );

            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }


        public bool ValidateToken(string authToken, out SecurityToken? validatedToken, out IPrincipal? principal)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters()
            {
                // Validates token expiry. Setting this to false will not validate token expiry.
                // Shouldn't be turned off, unless the token does not contain expiry (and hence a never expiring one).
                ValidateLifetime = true,

                // Validates the Audience field is the same as the one this application uses
                ValidateAudience = true,

                // Validates the Issuer field is the same as the one this application uses
                ValidateIssuer = true,

                // The expected Issuer value
                ValidIssuer = ISSUER,

                // The expected Audience value
                ValidAudience = AUDIENCE,

                // The same key as the one that generate the token
                IssuerSigningKey = securityKey,

                ClockSkew = TimeSpan.Zero,
            };

            try
            {
                                
                    principal  = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);

                    return true;
                
            }
            catch (SecurityTokenException tokenException)
            {
                validatedToken = null;
                principal = null;

                return false;
            }
        }


    }
}
