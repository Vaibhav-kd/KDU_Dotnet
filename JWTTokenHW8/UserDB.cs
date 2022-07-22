namespace JWTTokenHW8
{
    public class UserDB
    {
        public  List<User> users_data;

        public UserDB()
        {
            users_data = new List<User>()
            {
            new User {username= "Priyanshi" , password = "1234"},
            new User { username = "Ajit", password = "5678" },
            new User { username = "Vaibhav" , password="9012"},
            new User {username= "Yashika" ,password= "abcd"},
            new User {username = "Kaustubh", password = "efgh"},
            new User {username= "Raghu" , password ="ijkl"}
            };
        }


    }
}
