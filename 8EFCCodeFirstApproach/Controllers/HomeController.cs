using EFCCodeFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCCodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDB;

        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }
        public IActionResult Index()
        {
            
            var stdData = studentDB.Students.ToList(); 
            return View(stdData);
        }
    }
}
