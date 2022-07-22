using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using JwtWebApi.Models;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using Microsoft.Exchange.WebServices.Data;

namespace JWTTokenHW8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        //const string ISSUER = "issuing-website-url";
        //const string AUDIENCE = "target-website-url";
        const string key = "225e46a6fa5340b1a87b988e4e4326900c8bebf8668648579e91441d1158daf48eb60ad8d035492f8cc8846624eed68c2ee34e08db774af2bd94fb7b99f64ba7";

        private static readonly SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

       // public readonly UserDB userdb;
       UserDB userdb = new UserDB();
        List<User> user_list = userdb.users_data;

        public AuthController(UserDB userDB)
        {
            this.userdb = userDB;
        }





        public IConfiguration Configuration { get; }

        public AuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(User request)
        {
            
            var userNameCheck =  user_list.Where(x => x.username == request.username);
            if (userNameCheck==null)
            {
                return BadRequest("User not Found");
            }


            var userPasswordCheck =  user_list.Where(x => x.password == request.password);
            if (userPasswordCheck == null)
            {
                return BadRequest("Password is incorect");
            }
            string token = GenerateToken(request.username, request.password);
            return Ok(token);
        }

       


        private static string GenerateToken(string username, string password)
        {
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(
                signingCredentials: credentials,
                //issuer: ISSUER,
                //audience: AUDIENCE,
                claims: new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, username),
                    new Claim(JwtRegisteredClaimNames.AtHash, password)
                }
            );

            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }
    }
}
