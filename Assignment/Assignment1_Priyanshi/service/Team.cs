using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Priyanshi.service
{
    public class Team
    {
        public void Q7_predictionScore()
        {

            var result = Program.iplList
                             .GroupBy(x => new { x.team })
                             .Select(g => new { Average = g.Average(a => a.average), g.Key.team })
                             .OrderByDescending(x => x.Average).Take(2);

            foreach (var r in result)
            {
                var score= Math.Round(r.Average*11);
                Console.WriteLine(r.team + " : predicted score is : " + score);
            }

        }

    }

}
