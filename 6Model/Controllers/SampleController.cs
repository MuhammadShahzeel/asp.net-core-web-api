using _6Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace _6Model.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Data()
        {
            // manual list (no database yet)
            var students = new List<StudentModel>
            {
                new StudentModel { RollNo = 1, Name = "Ali Khan", Gender = "Male", Grade = "A" },
                new StudentModel { RollNo = 2, Name = "Sara Ahmed", Gender = "Female", Grade = "B" },
                new StudentModel { RollNo = 3, Name = "Bilal Sheikh", Gender = "Male", Grade = "A+" },
                new StudentModel { RollNo = 4, Name = "Fatima Noor", Gender = "Female", Grade = "C" }
            };

            //api hit krny pe json my data mily ga then frontend pr bnda map lga le hahaha
            return Ok(students);
        }
    }
}
