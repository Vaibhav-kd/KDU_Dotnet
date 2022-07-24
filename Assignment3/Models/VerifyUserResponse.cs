namespace Assignment3.Models
{
    public class VerifyUserResponse
    {
        public List<string> error { get; set; }
  
        public string token{ get; set; } = string.Empty;

        public VerifyUserResponse() {
            error=new List<string>();
        }
    }
}
