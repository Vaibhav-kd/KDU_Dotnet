using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment1_Priyanshi.Program;

namespace Assignment1_Priyanshi.service
{
    public class Menu
    {
        public void MainMenu()
        {
            Console.WriteLine("Choose an option from the menu:");
            Console.WriteLine("1: Get Match Fixtures List");
            Console.WriteLine("2: All the bowlers who have taken at least 40 wickets");
            Console.WriteLine("3: Search a player feature");
            Console.WriteLine("4: The details of the highest wicket-taker and highest run-scorer ");
            Console.WriteLine("5: The top 3 batsmen, top 3 bowlers, and top 3 all-rounders of the season");
            Console.WriteLine("6: The teams which would score the highest and their predicted score ");
            Console.WriteLine("7: The next-gen of players for each team");
            Console.WriteLine("8: To get out of this menu.");

            string? input = Console.ReadLine();
            Players players = new Players();
            switch (input)
            {
                case "1":
                    Console.WriteLine("....");
                    break;
                case "2":
                    Console.WriteLine("Name of the team: ");
                    string team_name = Console.ReadLine();

                    players.Q3_bowlers40(team_name);
                    break;
                case "3":
                    Console.WriteLine("Name of player to display profile");
                    string player_name = Console.ReadLine();
                    players.Q4_display(player_name);
                    break;
                case "4":
                    Console.WriteLine("Enter Name: ");
                    string inp = Console.ReadLine();
                    players.Q5_HighestScorer();
                    break;
                case "5":
                    players.Q6_TopThree();
                    break;
                case "6":
                    Team teams = new Team();
                    teams.Q7_predictionScore();
                    break;
                case "7":
                    
                    players.NextGen();
                    break;
                case "8":
                    check= false;
                    break;
                default:
                    break;
            }

        }
    }
}
