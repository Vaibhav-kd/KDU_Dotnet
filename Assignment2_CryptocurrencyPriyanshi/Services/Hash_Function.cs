using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_newAttempt.Services
{
    public class Hash_Function
    {
        public void GetBlockHash()
        {
            string SALTCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder transactionHash = new StringBuilder();
            Random rnd = new Random();
            /**
            * Introducing delay mimicking complex
            * calculation being performed.
*/
            for (double i = 0; i < 199999999; i++)
            {
                i = i;
            }
            while (transactionHash.Length < 128)
            {
                int index = Convert.ToInt32((rnd.NextSingle() * SALTCHARS.Length));
               
            }
            String hashCode = transactionHash.ToString();
           
        }

    }
}
