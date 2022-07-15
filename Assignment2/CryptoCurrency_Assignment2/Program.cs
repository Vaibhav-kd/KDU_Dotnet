namespace CryptoCurrency_Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void Menu_options()
            {
                Console.WriteLine("Choose the option ammonst the following displayed options ");

                Console.WriteLine("1. Give the name or code of a coin, retrieve all its details." +
                        "\n 2. Display top 50 coins in the market based on price." +
                        "\n 3. Show portfolio of a Trader" +
                        "\n 4. Show the total profit or loss they have made trading in the crypto market" +
                        "\n 5. Exit!");

                //Displayed the menu functionality on Console with 5 options .
            }

            void Choose_Desired_option()
            {       // this method asks user for the input while printing the menu.
                var status = true;
                while (status)
                {
                    Menu_options();
                    Console.WriteLine("Enter the option");
                    var option = Console.ReadLine(); // User_input 
                    switch (option)
                    {
                        case "1":
                            try
                            {
                                functionality.coinDetails();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;

                        case "2":
                            try
                            {
                                Console.WriteLine("The top 50 Coins are as follow: ");
                                functionality.top50Coins();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;

                        case "3":
                            try
                            {
                                Console.WriteLine("Enter the Full Name of Trader:");
                                var name = Console.ReadLine();
                                functionality.TraderPortfolio(name.ToUpper);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                            break;

                        case "4":
                            try
                            {
                                Console.WriteLine("Enter the Full Name of Trader:");
                                var name = Console.ReadLine();
                                MenuFunctions.ProfitLossOfTrader(name.ToUpper);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                            break;


                        case "5":
                            status = false;
                            break;

                        default:
                            Console.WriteLine("oops! wrong input..");
                            break;
                    }




                }
            }
        }

    }
}