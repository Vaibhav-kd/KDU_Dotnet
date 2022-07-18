using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Priyanshi.service
{
    internal class Players
    {
        public void Q3_bowlers40(string team)
        {
            var res = from i in Program.iplList
                      where i.team == team
                      where i.wickets >= 40
                      select i;
            foreach (var i in res)
            {
                Console.WriteLine(i.name);
            }
        }


        public void Q4_display(string value)
        {
            var result = Program.iplList.Where(s => s.name.Contains(value));
            int num = 1;
            foreach (var i in result)
            {
                Console.WriteLine("Profile no:" + num);
                Console.WriteLine("Name: "+i.name);
                Console.WriteLine("Wickets: "+i.wickets);
                Console.WriteLine("Average: "+i.average);
                Console.WriteLine("Strike rate: "+i.sr);
                Console.WriteLine("...........................................");
                num++;
            }
            Console.ReadLine();
        }

        public void Q5_HighestScorer()
        {
            var wicketsScorer = Program.iplList.
                                        OrderByDescending(x => x.wickets)
                                        .FirstOrDefault();

            Console.WriteLine(wicketsScorer.name);
            var runsScorer = Program.iplList
                                    .OrderByDescending(x => x.runs)
                                        .FirstOrDefault();
            Console.WriteLine(runsScorer.name);

        }

        public void Q6_TopThree()
        {

            var batsmen3 = Program.iplList.OrderByDescending(x => x.runs).Take(3);
            Console.WriteLine("Top 3 Batsmen are: ");
            foreach (var top in batsmen3)
            {
                Console.WriteLine(top.name);
            }
            Console.WriteLine("...........................................");
            var bowlers3 = Program.iplList.OrderByDescending(x => x.wickets).Take(3);
            Console.WriteLine("Top 3 Bowlers are: ");
            foreach (var top in bowlers3)
            {
                Console.WriteLine(top.name);
            }
            Console.WriteLine("...........................................");
            Console.WriteLine("Top AllRounders are: ");
            var allRounders3 = Program.iplList.OrderByDescending(a => a.runs).ThenBy(a => a.wickets).Take(3);
            foreach (var top in allRounders3)
            {
                Console.WriteLine(top.name);
            }
            Console.WriteLine("...........................................");
        }


        public void NextGen()
        {
            var players= Program
                                .iplList
                                .Where(x => x.matches <= 20 && x.matches >= 4);
            var Next_Gen_Bowlers = players
                                          .OrderByDescending(x => x.wickets)
                                          .Take(5);
            var Next_Gen_Batsmen = players
                                          .OrderByDescending(x => x.wickets)
                                          .Take(5);
            var Next_Gen_All_rounders = players
                                               .Where(x => x.role == "ALL ROUNDER")
                                               .OrderByDescending(x => x.wickets * x.average).Take(5);
            foreach (var i in Next_Gen_Bowlers)
            {
                Console.WriteLine("Next Gen Bowler is/are: " + " " + i.name);
            }
            foreach (var i in Next_Gen_Batsmen)
            {
                Console.WriteLine("Next Gen Batsman is/are: " + " " + i.name);
            }
            foreach (var i in Next_Gen_All_rounders)
            {
                Console.WriteLine("Next Gen Allrounder is/are:  " + " " + i.name);
            }
            Console.ReadLine();
        }
    }
}
