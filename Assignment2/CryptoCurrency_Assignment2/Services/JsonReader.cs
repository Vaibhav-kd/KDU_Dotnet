using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency_Assignment2.Services
{
    internal class JsonReader
    {
        JObject data = JObject.Parse(File.ReadAllText(@"JsonFiles\test_transaction.json"));


    }



}
   
