namespace Assignment3.Models
{
    public class FlightDetailsResponse
    {
        public List<Airplane> airplanes { get; set; }
        public string error {get; set; } = string.Empty;
        
        public FlightDetailsResponse()
        {
            airplanes=new List<Airplane>();
        }
    }
}
