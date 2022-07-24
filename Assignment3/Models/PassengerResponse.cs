namespace Assignment3.Models
{
    public class PassengerResponse
    {
        public Passenger passenger { get; set; }
        public string error { get; set; } = string.Empty;

        public PassengerResponse()
        {
            passenger = new Passenger();
        }

    }
}
