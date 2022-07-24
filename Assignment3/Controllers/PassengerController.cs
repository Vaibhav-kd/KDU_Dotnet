using Assignment3.Models;
using Assignment3.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerServices passengerServices;

        public PassengerController(PassengerServices passengerServices)
        {
            this.passengerServices = passengerServices;
        }

        //Passenger/Ticket is used to get the ticket of a passenger via passenger via passenger id. 

        [HttpGet("Ticket")]
        public PassengerResponse GetTicket(int passengerId)
        {
            var result = passengerServices.ViewTicket(passengerId);
            return result;
        }

        //Pasenger/transaction is used to get the passenger details of a user via order id and user id.
        [HttpGet("transaction")]
        public TransactionResponse GetTransaction(int userId, int orderId)
        {
            var result = passengerServices.ViewPaymentDone(userId, orderId);
            return result;

        }
        // Passenger/cancel is used to post Cancel ticket using cancelTicketRequest which is a class in models folder.

        [HttpPost("cancel")]
        public ErrorResponse PostCancelTicket(CancelTicketRequest cancelTicketRequest)
        {

            var result = passengerServices.CancelTicket(cancelTicketRequest.passengerId);
            return result;
        }

        //Passenger/book is used to book the ticket for a user using bookTicketRequest model . 
        [HttpPost("book")]
        public ErrorResponse PostBookTicket(BookTicketRequest bookTicketRequest)
        {
            var result = passengerServices.BookATicket(bookTicketRequest.userId, bookTicketRequest.username, bookTicketRequest.email, bookTicketRequest.password, bookTicketRequest.contactId, bookTicketRequest.phone, bookTicketRequest.type, bookTicketRequest.flightinstID, bookTicketRequest.age, bookTicketRequest.sex);
            return result;
        }


    }
}
