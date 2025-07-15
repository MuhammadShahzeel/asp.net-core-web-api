using EFCCodeFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCCodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDB;

        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }
        public async Task<IActionResult> Index()
        {

            var stdData = await studentDB.Students.ToListAsync();
            return View(stdData);
        }
        public IActionResult Create()
        {


            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || studentDB.Students== null) { 
                return NotFound();
            }

            var stdData = await studentDB.Students.FirstOrDefaultAsync(x=>x.Id==id);
            if (stdData == null) {
                return NotFound();
            }

            return View(stdData);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid) { 
               await studentDB.Students.AddAsync(std);
               await  studentDB.SaveChangesAsync();
               return RedirectToAction("Index","Home");
            }
            
   
            return View(std);
        }
    }
}
