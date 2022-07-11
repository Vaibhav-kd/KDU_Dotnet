using DependencyInjection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentRepository studentRepository;
        public StudentController(StudentRepository studentRepository)         //Passing myObject in as an argument to the constructor
        {
            this.studentRepository = studentRepository;                      //injecting the dependencies (StudentRepository) at runtime.
        }

        public IActionResult Index()
        {
            return View();
        }

    }


}
