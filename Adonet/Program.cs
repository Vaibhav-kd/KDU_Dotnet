using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Adonet
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

                //Insertion 

                var sqlCommandInsert = new SqlCommand("Insert into Products values(79,'ABCDEF',3,7,'12 - 550 ml bottles',18.00,56,10,1,0", sqlConnection);
                var dataReader1 = sqlCommandInsert.ExecuteNonQuery();
                Console.WriteLine("Totals Rows Inserted =" + dataReader1.ToString());



                //Updation

                var sqlCommandUpdate = new SqlCommand("Update Products set UnitPrice=50.00 where ProductID=65", sqlConnection);
                var dataReader2 = sqlCommandUpdate.ExecuteNonQuery();
                Console.WriteLine("Totals Rows Updated=" + dataReader2.ToString());



                //Deletion
                var sqlCommandDelete = new SqlCommand("Delete from Products where ProductID=70", sqlConnection);
                var dataReader3 = sqlCommandDelete.ExecuteNonQuery();
                {
                    Console.WriteLine("Totals Rows Deleted =" + dataReader3.ToString());

                }
            }
        }
    
    }
}
