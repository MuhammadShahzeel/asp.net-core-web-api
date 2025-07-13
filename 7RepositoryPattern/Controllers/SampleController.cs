using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories;
using System.Collections.Generic;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        //private readonly IStudentRepository _studentRepository;
        // ⭐ Simple Constructor
        public SampleController()
        {
            _studentRepository = new StudentRepository();
        }

        // ⭐ GET: api/sample
        [HttpGet]
        //yeh bhi likh skty hen is sy ziada wazy hojae ga
        //public ActionResult<List<StudentModel>> GetStudents()
        public IActionResult GetStudents()
        {
            var students = _studentRepository.GetAllStudents();
            return Ok(students);
        }

        // ⭐ GET: api/sample/2
        [HttpGet("{id}")]
        //yeh bhi likh skty hen 
        //public StudentModel GetStudentById(int id)
        public IActionResult GetStudentById(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound($"Student with RollNo {id} not found.");
            }
            return Ok(student);
        }
    }
}
