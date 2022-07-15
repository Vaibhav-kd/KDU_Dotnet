using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency_Assignment2.Models
{
    internal class HashFunction
    {
        /*
 Method generates the unique block hash required
 for transactions made using the cryptocurrencies
 @return - string representing the transaction hashcode
*/

        string GetBlockHash()
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
                int index = Convert.ToInt32((rnd.NextSingle() *
                SALTCHARS.Length));
                transactionHash.Append(SALTCHARS.ElementAt(index));
            }
            String hashCode = transactionHash.ToString();
            return "0x" + hashCode.ToLower();
        }
    }
}
