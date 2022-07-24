namespace Assignment3.Models
{
    public class UserDetailsResponse
    {
        public List<User> user { get; set; }
        public string error { get; set; } = string.Empty;

        public UserDetailsResponse()
        {
            user = new List<User>();
        }

    }
}
