using Assignment3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Assignment3.services
{
    public class UserServices
    {

        private readonly Flight_Database_SystemContext dbContext;
        public List<FlightInstance> airplaneList { get; set; }

        const string ISSUER = "issuing-website-url";
        const string AUDIENCE = "target-website-url";

        const string key = "225e46a6fa5340b1a87b988e4e4326900c8bebf8668648579e91441d1158daf48eb60ad8d035492f8cc8846624eed68c2ee34e08db774af2bd94fb7b99f64ba7";

        private static readonly SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));


        public UserServices(Flight_Database_SystemContext dbContext)
        {
            this.dbContext = dbContext;           

        }

       //Verify user through username and passworod and then generate token
        public string VerifyUSer(int UserId, string UserName, string Password)
        {

            var userNameCheck = dbContext.Users.Where(x => x.UserName == UserName);
            if (userNameCheck == null)
            {
                throw new Exception("Bad Request, username not found");
            }

            var userPasswordCheck = dbContext.Users.Where(x => x.Password == Password);
            if (userPasswordCheck == null)
            {
                throw new Exception("Bad Request,password not found");

            }
            string token = GenerateToken(UserId, UserName, Password);
            return token;
        }

        // create a user by taking input parameters and then add it to the database
        public void CreateUser(string userName, string email, string password,int contactid, int contact)
        {

            var newUser = new User
            {
                UserId =  dbContext.Users.Count() + 1,
                UserName = userName,
                Email= email,
                Password= password,
                ContactId= contactid ,
            };

            dbContext.Users.Add(newUser);
        }

        public IEnumerable<User> UserDetails(int UserID)
        {
            //UserDetailsResponse userDetailsResponse = new UserDetailsResponse();
            var user= dbContext.Users.Where(x=>x.UserId==UserID).ToList();
           
            return user;
        }

        public IEnumerable<FlightInstance> viewFlightDetails(int sourceCode, int destinationCode)
        {
           //FlightDetailsResponse flightDetailsResponse = new FlightDetailsResponse();

            var required_Route = dbContext.Routes.Where(x => (x.ArrivalAirportCode == destinationCode && x.DeparureAirportCode == sourceCode)).Select(x => x.RouteId).ToList();
            
            foreach (var i in required_Route)
            {
                airplaneList = new List<FlightInstance>();

                var plane = dbContext.FlightInstances.Where(x => x.RouteId == i).SingleOrDefault();
             airplaneList.Add(plane);                
            }
           // flightDetailsResponse.airplanes = airplaneList;
            return airplaneList;
        }

        //DElete user through userId 
        public  ErrorResponse Delete(int userId)
        {
            ErrorResponse errorResponse = new ErrorResponse();
            var existingUser = dbContext.Users.SingleOrDefault(s => s.UserId == userId);

            if (existingUser == null)
                errorResponse.error.Add($"Student with ID '{userId}' was not found!");

            dbContext.Users.Remove(existingUser);
            return errorResponse;
        }

        //A token is generated using userId , username and password.
        private static string GenerateToken(int userId, string username, string password)
        {
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(
                signingCredentials: credentials,
                issuer: ISSUER,
                audience: AUDIENCE,
                claims: new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, username),
                    new Claim(JwtRegisteredClaimNames.Sub,password )
                }
            );

            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }

        //The generated token is then validated
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
                principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);

                return true;
            }
            catch (SecurityTokenException tokenException)
            {
                //tokenException.Dump("Security Token Exception");

                validatedToken = null;
                principal = null;

                return false;
            }
        }

    }

}

