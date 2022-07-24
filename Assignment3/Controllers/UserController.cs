using Assignment3.Models;
using Assignment3.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices userServices;
        private string token;
        private bool isValidated;


        public UserController(UserServices userServices)
        {
            this.userServices = userServices;

        }

        //User/login is used to verify user uding username and password and generate token

        [HttpPost("login")]
        public VerifyUserResponse login(LoginRequest loginRequest)
        {
            VerifyUserResponse response = new VerifyUserResponse();
            var user = new User
            {
                UserId = loginRequest.userID,
                UserName = loginRequest.username,
                Password = loginRequest.password,
            };
            response.token = userServices.VerifyUSer(loginRequest.userID, loginRequest.username, loginRequest.password);
            token = response.token;
            return response;
        }



        // GET api/<UserController>/2
        [HttpGet("userId")]
        public IEnumerable<User> Get(int userId, string token)
        {
            isValidated = userServices.ValidateToken(token, out var validatedToken, out var principal);
            
            var user = userServices.UserDetails(userId);

            return user;


        }

        // POST api/<UserController>/CreateUser
        [HttpPost("CreateUser")]
        public void Post(CreateUserRequest createUserRequest)
        {
            userServices.CreateUser(createUserRequest.userName, createUserRequest.email, createUserRequest.password, createUserRequest.contactid, createUserRequest.contact);
        }


        // GET api/<UserController>/FlightDetails
        [HttpGet("FlightDetails")]
        public IEnumerable<FlightInstance> GetFlight(int sourceCode, int departureCode)
        {
            var airplanes = userServices.viewFlightDetails(sourceCode, departureCode);
            return airplanes;
        }


        [HttpDelete("DeleteUser")]
        public ErrorResponse Delete(int userID)
        {

            var errorResponse = new ErrorResponse();
            userServices.Delete(userID);
            return errorResponse;
        }


    }
}
