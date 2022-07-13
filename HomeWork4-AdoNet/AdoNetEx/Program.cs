using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AdoNetSample
{
    internal class Program
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["NorthwindDb"].ConnectionString;

        static void Main(string[] args)
        {
             DataReaderDemo();
           

            Console.ReadKey();
        }

        private static void DataReaderDemo()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                using (var sqlCommandInsert = new SqlCommand("Insert into FROM Orders values(11111, 'Priyanshi',4,'1996-07-12 00:00:00.000','1996-07-24 00:00:00.000','1996-07-16 00:00:00.000',2,41.34,'Centro comercial Moctezuma', 'rue du Commerce','Reims',NULL,474010,'France')", sqlConnection))
                using (var dataReader = sqlCommand.ExecuteNonQuery())
                {
                    

                        Console.WriteLine("Totals Rows Inserted =" +dataReader.ToString());
                    
                }

                using (var sqlCommandUpdate = new SqlCommand("Update Orders set freight=50 where OrderID=10252", sqlConnection))
                using (var dataReader = sqlCommand.ExecuteNonQuery())
                {
                    Console.WriteLine("Totals Rows Updated=" +dataReader.ToString());
                                         
                }


                using (var sqlCommandDelete = new SqlCommand("Delete from Orders where OrderID=10252", sqlConnection))
                using (var dataReader = sqlCommand.ExecuteNonQuery())
                {                    
                        Console.WriteLine("Totals Rows Deleted =" +dataReader.ToString());
                                          
                }
            }
        }
    }
}