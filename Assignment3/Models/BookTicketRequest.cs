namespace Assignment3.Models
{
    public class BookTicketRequest
    {
        //int userID, string username, string email, string password, int contactId, string type, int flightinstID, int age, string sex
        //bookTicketRequest.UserId, bookTicketRequest.UserName, bookTicketRequest.Email, bookTicketRequest.Password, bookTicketRequest.ContactId
        public int  userId { get; set; }

        public string username{get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int contactId { get; set; }

        public int phone { get; set; }
        public string type { get; set; }
        public int flightinstID{ get; set; }
        public int age { get; set; }

        public string sex { get; set; }



    }
}
