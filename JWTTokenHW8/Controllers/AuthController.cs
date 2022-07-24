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
using JWTTokenHW8.Services;

namespace JWTTokenHW8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly userServices us;
        private string token;

        public AuthController(userServices us)
        {
            this.us = us;
        }

        // At this endpoint i am checking if the user exists or not and if it does , generate a token for user . 
        [HttpPost("login")]
        public string Login(string username, string password)
        {

            var userNameCheck = us.users_data.Where(x => x.username == username);

            if (userNameCheck == null)
                return "USer not found!";



            var userPasswordCheck = us.users_data.Where(x => x.password == password);

            if (userPasswordCheck == null)

                return "Password is incorect";

            token = us.GenerateToken(username, password);
            return token;
        }


        [HttpPost("ViewUser")]
        public string View(string username)
        {


            var a = us.users_data.Where(x => x.username == username).SingleOrDefault();
            return a.percentage;

        }
    }
}
