using Assignment3.Models;

namespace Assignment3.services
{
    public class PassengerServices
    {
        private readonly Flight_Database_SystemContext dbContext;
        public PassengerServices(Flight_Database_SystemContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public PassengerResponse ViewTicket(int PassengerId)
        {
            PassengerResponse response = new PassengerResponse();

            //Returns passenger details using pasenger id. 
            response.passenger = dbContext.Passengers.Where(x => x.PassengerId == PassengerId).SingleOrDefault();
            //Error handling

            if (response.passenger == null)
                response.error="Passenger doesn't exist" ;

            return response;


        }

        public ErrorResponse CancelTicket(int passengerId)
        {
            ErrorResponse errorResponse = new ErrorResponse();

            //In Passenger change status of cancelled and confirmed
            var passenger = dbContext.Passengers.Where(x => x.PassengerId == passengerId).SingleOrDefault();
            //Error handling
            if (passenger == null)
                errorResponse.error.Add("Passenger not found");

            passenger.Cancelled = "Y";
            passenger.Confirmed = "N";
            dbContext.SaveChanges();

            var passengerflightInstanceId = passenger.FlightInstId;
            var passengerflightSeatType = passenger.Type;

            //Also increase seat count for that particularf seat in flight instance
            var flight = dbContext.FlightInstances.Where(x => x.InstanceId == passengerflightInstanceId).SingleOrDefault();

            //Error handling
            if (flight == null)
                errorResponse.error.Add("Flight doesn't exist!");

            switch (passengerflightSeatType)
            {
                case "E":
                    flight.ESeats += 1;
                    break;
                case "B":
                    flight.BSeats += 1;
                    break;
                case "F":
                    flight.FSeats += 1;
                    break;
                default:
                    break;
            }
            return errorResponse;
        }

        public ErrorResponse BookATicket(int userid,string username, string email,string password, int contactid,int phone,string type, int flightinstID, int age, string sex)
        {
            ErrorResponse errorResponse = new ErrorResponse();
            if (userid == null)
                errorResponse.error.Add("User not found");

            //Create a passenger with given details
            Passenger newPassenger = new Passenger
            {
                PassengerId = dbContext.Passengers.Count() + 1,
                PassengerName =username,
                Type = type,
                SeatNo = dbContext.FlightInstances.Where(x => x.InstanceId == flightinstID).Count() + 1,
                UserId = userid,
                FlightInstId = flightinstID,
                EmailId = email,
                Phone = phone,
                Age = age,
                Sex = sex,
                Confirmed = "Y",
                Cancelled = "N"

            };
            dbContext.Passengers.Add(newPassenger);
          //  dbContext.SaveChanges();

            return errorResponse;
        }

        public TransactionResponse ViewPaymentDone(int userId, int orderId)
        {
            //Get payment details using used id and order id 

            TransactionResponse paymentDetails = new TransactionResponse();

            paymentDetails.transaction = dbContext.Transactions.Where(x => (x.OrderId == orderId && x.UserId == userId)).SingleOrDefault();

            if (paymentDetails.transaction == null)
                paymentDetails.error = $"Transaction of user with user id '{userId}' , and OrderID '{orderId}' was not found!";
                
            return paymentDetails;

        }

    }
}
