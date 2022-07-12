using Homework3Pagination.Services;

namespace Homework3Pagination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new TestServices();

            service.GetTotalScore(17,5);
            
        }
    }
}