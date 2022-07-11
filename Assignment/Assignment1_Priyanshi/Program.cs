namespace Assignment1_Priyanshi
{
    internal class Program
    {
        public static List<IPL> iplList = new List<IPL>();
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
                 new KeyValuePair<string, string>("SR", "strikeRate"),
                 new KeyValuePair<string, string>("Wickets", "wickets")
            };
            iplList = getData.Data<IPL>(@"C:\Users\KD Administrator\Downloads\IPL_2021_data.csv");

            Players players = new Players();
            string team = Console.ReadLine();
            Console.WriteLine("Players with >=40 wickets: ",players.Q3_bowlers40(team));

            Console.WriteLine(players.Q4_display("CSK"));

            Console.WriteLine("Highest-Scorer are: ");
            foreach(var i in players.Q5_HighestScorer())
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Top3 are: ");
            foreach (var i in players.Q6_TopThree())
            {
                Console.WriteLine(i);
            }

            Team t = new Team();
            t.Q7_predictionScore();         


            }
        

        // This function fetches the data from given csv file , under headers from row[0] using File functions.
        // Then formulated the fetched info.
        public class GetDataCSV
        {
            public List<KeyValuePair<string, string>> Mappings;
            public List<T> Data<T>(string file)
            {
                List<T> l = new List<T>();
                List<string> fetchData = System.IO.File.ReadAllLines(file).ToList();
                string headerLine = fetchData[0];
                var headerInfo = headerLine.Split(',').ToList().Select((x, y) => new
                {
                    Name = x,    
                    Index = y
                });
                Type type = typeof(T);
                var properties = type.GetProperties();
                var dataLines = fetchData.Skip(1);
                dataLines.ToList().ForEach(line =>
                {
                    var values = line.Split(',');
                    T obj = (T)Activator.CreateInstance(type);
                    foreach (var prop in properties)
                    {
                        
                        var mapping = Mappings.SingleOrDefault(m => m.Value == prop.Name);
                        var cname = mapping.Key;
                        var cindex = headerInfo.SingleOrDefault(s => s.Name == cname).Index;
                        var value = values[cindex];
                        var propType = prop.PropertyType;
                        prop.SetValue(obj, Convert.ChangeType(value, propType));
                    }
                    l.Add(obj);
                });
                return l;
            }
        }

        //Created an IPL  class  having req. property declarations.
        public class IPL
        {

            public string name { get; set; }
            public string team { get; set; }
            public string role { get; set; }
            public int matches { get; set; }
            public int runs { get; set; }
            public double average { get; set; }
            public double sr { get; set; }
            public int wickets { get; set; }
        }


        

        // Players class have implementation of queries to fetch req. data
        public class Players
        {
            
            public List<string> Q3_bowlers40(string team)
            {
                List<string> ans = new List<string>();
                var res = from i in Program.iplList
                             where i.name == team
                             where i.wickets >= 40
                             select i;
                foreach (var i in res)
                {
                   ans.Add(i.name);
                }
                return ans;

            }


            public IEnumerable<string> Q4_display(string value)
            {
                IEnumerable<string> result = (IEnumerable<string>)Program.iplList.Where(s => s.name.Contains(value));
                return result;
            }

            /*public void Q6_nextGen()
            {
                List<string> next_gen = new List<string>();
                var gen = Program.iplList.GroupBy(t => new { team = t.team }).Select(g => new { Average = g.Average(p => p.average), team = g.Key.team })
                                    .OrderByDescending(x => x.Average).Take(2);

                
             }*/

            public List<string> Q6_TopThree()
            {
                List<string> top3 = new List<string>();

                var batsmen3 = Program.iplList.OrderByDescending(x => x.runs).Take(3);
                foreach (var top in batsmen3)
                {
                    top3.Add(top.name);
                }
                var bowlers3 = Program.iplList.OrderByDescending(x => x.wickets).Take(3);
                foreach (var top in bowlers3)
                {
                    top3.Add(top.name);
                }
                var allRounders3 = Program.iplList.OrderByDescending(a => a.runs).ThenBy(a => a.wickets).Take(3);
                foreach (var top in allRounders3)
                {
                    top3.Add(top.name);
                }

                return top3;


            }

            public List<string> Q5_HighestScorer()
            {
                List<string> highest_scorer = new List<string>();

                var wicketsScorer = Program.iplList.
                                            OrderByDescending(x => x.wickets)
                                            .FirstOrDefault();
                highest_scorer.Add(wicketsScorer.name);

                var runsScorer = Program.iplList
                                        .OrderByDescending(x => x.runs)
                                            .FirstOrDefault();
                highest_scorer.Add(runsScorer.name);
                return highest_scorer;
            }




        }

        public class Team
        {
            public void Q7_predictionScore()
            {
                
                var result = Program.iplList
                                 .GroupBy(x => new { team = x.team })
                                 .Select(g => new { Average = g.Average(a => a.average), team = g.Key.team })
                                 .OrderByDescending(x => x.Average).Take(2);
               
                foreach (var r in result)
                {
                    Console.WriteLine(r.team + " : predicted score is : " + r.Average * 11);
                }

            }

        }
    }
}
