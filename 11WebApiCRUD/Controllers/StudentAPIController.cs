using _11WebApiCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _11WebApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentsWebApiDbContext context;

        public StudentAPIController(StudentsWebApiDbContext context)
        {
            this.context = context;
        }

        //get all students
        [HttpGet]
        public async Task<ActionResult<List<StudentsWebApi>>> GetStudents() //StudentsWebApi class
        {
            var students=  await  context.StudentsWebApis.ToListAsync();
            return Ok(students);

        }

        //get a single student by id
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsWebApi>> GetStudentById(int id)
        {
            var student = await context.StudentsWebApis.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        //insert data
        [HttpPost]
        public async Task<ActionResult<StudentsWebApi>> InsertStudent(StudentsWebApi student)
        {
           
            context.StudentsWebApis.Add(student);
            await context.SaveChangesAsync();
            return  Ok(student);
        }

        //update data
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentsWebApi>> UpdateStudent(int id, StudentsWebApi student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            context.Entry(student).State = EntityState.Modified;
            await context.SaveChangesAsync();
 
            return Ok(student);
        }
        //delete data
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await context.StudentsWebApis.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            context.StudentsWebApis.Remove(student);
            await context.SaveChangesAsync();
            return NoContent();
        }






    }
}
