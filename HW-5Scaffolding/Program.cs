using HW_5Scaffolding.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HW_5Scaffolding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json");

            var config = configuration.Build();

            var connectionString = config.GetConnectionString("NorthwindDbConnection");

            var options = new DbContextOptionsBuilder<NorthwindContext>()
                                .UseLazyLoadingProxies()
                                .UseSqlServer(connectionString)
                                .Options;

            var dbContext = new NorthwindContext(options);

            // Query-1  Given a user ID return the territory name of that employee.


            var input = 4;

            var query1 = dbContext.Employees.Where(e => e.EmployeeId == input).Include(e => e.Territories).ToList();

            foreach (var i in query1)
            {
                foreach (var e in i.Territories)
                    Console.WriteLine("Territory name for employee ID is " + e.TerritoryDescription);
            }


            // Query-2 Give the name of employess with maximum number of sales


            var query2 = dbContext.Employees.Include(a => a.Orders);


            //Query-3  Give a list of product name and the nam eof country they are shipped to

            var query3 = dbContext.Invoices.
                        Select(a => new
                        {
                            productname = a.ProductName,
                            ship_con = a.ShipCountry
                        }).ToList();

            foreach (var i in query3)
                Console.WriteLine(i.productname + " " + i.ship_con);



            // Query-4 Give a list of products, total quantity of the products sold, and total money earned from that product

            var query4 = dbContext.OrderDetails
                          .Select(a => new
                          {
                              productId = a.ProductId,
                              tQuantity = a.Quantity,
                              moneyEarned = (double)(a.UnitPrice) * (1 - (a.Discount)) * (a.Quantity)

                          }).ToList();
            foreach (var x in query4)
            {
                Console.WriteLine(x.productId + " " + x.tQuantity + " " + x.moneyEarned);


                Console.ReadLine();


            }
        }
    }