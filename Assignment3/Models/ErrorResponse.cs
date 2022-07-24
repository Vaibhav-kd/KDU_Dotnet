namespace Assignment3.Models
{
    public class ErrorResponse
    {
        public List<string> error { get; set; } 

        public ErrorResponse()
        {
            error = new List<string>();
        }
    }
}
