using DependencyInjection.Models;

namespace DependencyInjection.Services
{
    // Made a Student Repository which has students' data . 
    public class StudentRepository
    {
        private static readonly List<Student> students = new List<Student>();

        static StudentRepository()
        {
            students = new List<Student>()
            {
                new Student{Id=1 , Name= "Priyanshi"},
                new Student{Id=2 , Name= "Kimaya"},
                new Student{Id=3 , Name= "Ashmi"}

        };

        }

        public StudentRepository()
        {

        }

    }
}
