using Assignment1_Priyanshi.Model;
using Assignment1_Priyanshi.service;

namespace Assignment1_Priyanshi
{
    internal class Program
    {
        public static List<IPL> iplList = new List<IPL>();
        static public bool check;
        public static void Main()
        {
            var getData = new GetDataCSV();
            getData.Mappings = new List<KeyValuePair<string, string>>
            {
                 new KeyValuePair<string, string>("Name", "name"),
                 new KeyValuePair<string, string>("Team", "team"),
                 new KeyValuePair<string, string>("Role", "role"),
                 new KeyValuePair<string, string>("Matches", "matches"),
                 new KeyValuePair<string, string>("Runs", "runs"),
                 new KeyValuePair<string, string>("Average", "average"),
                 new KeyValuePair<string, string>("SR", "sr"),
                 new KeyValuePair<string, string>("Wickets", "wickets")
            };
            iplList = getData.Import<IPL>(@"C:\Users\KD Administrator\Desktop\KDUPRI\Assignment\Assignment1_Priyanshi\CSV_File\IPL_2021_data.csv");

            Menu menu = new Menu();
            check = true;
            while (check)
            {
                Console.WriteLine();
                menu.MainMenu();
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
