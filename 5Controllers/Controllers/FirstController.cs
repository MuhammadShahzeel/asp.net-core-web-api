using Microsoft.AspNetCore.Mvc;

namespace _5Controllers.Controllers
{
    /*
     * ================================================
     * ASP.NET Core Web API CONTROLLER - Beginner Guide
     * ================================================
     *
     * 📌 CONTROLLER KA ROLE:
     * - Client ki HTTP request ko accept karna
     * - Action method chalana
     * - Response wapas bhejna (usually JSON)
     *
     * 📌 ROUTING:
     * - [Route("api/[controller]")] => controller name se route banega
     * - "MyFirstController" => "myfirst"
     * - Base URL: /api/myfirst
     *
     * 📌 ACTION METHODS:
     * - Must be **public**
     * - Only public methods client ki request handle kar sakti hain
     */

    [Route("api/[controller]")]
    [ApiController]
    public class MyFirstController : ControllerBase
    {

        //simple string return type

        [HttpGet("[action]")]
        public string Abc()
        {

            return "Hello from string";
        }









        /*
         * ========================================
         * Example 1: Simple GET
         * ========================================
         * ✅ URL:
         *   GET /api/myfirst/hello
         * ✅ Returns:
         *   A simple string message
         */
        [HttpGet("hello")]
        public IActionResult SayHello()
        //    IActionResult ASP.NET Core Web API mein action methods ka flexible return type hai jo tumhein kisi bhi type ka HTTP response (200 OK, 404 NotFound, 400 BadRequest) aur koi bhi data(string, integer, JSON object, array) bhejne ki facility deta hai.
        {
            return Ok("Hello from Web API! This is your first GET response.");
        }

        /*
         * ========================================
         * Example 2: GET with Query Parameter
         * ========================================
         * ✅ URL:
         *   GET /api/myfirst/shahzeel
         * ✅ Returns:
         *   A JSON object with personalized message
         */
        [HttpGet("{name}")]
        public IActionResult GreetUser(string name)
        {
            string message = $"Hello, {name}! Welcome to your first API.";
            return Ok(new { Message = message });
        }

        [HttpGet("error")]
        public IActionResult Error()
        {

            return BadRequest(new { Message = "something went wrong" });
        }

        /*
         * ========================================
         * Example 3: GET Returning Multiple Items
         * ========================================
         * ✅ URL:
         *   GET /api/myfirst/users
         * ✅ Returns:
         *   A hard-coded list of users 
         *   Each user is represented as an anonymous object
         */
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            // 
            var users = new[]
            {
                new { Id = 1, Name = "Ali", Email = "ali@example.com" },
                new { Id = 2, Name = "Sara", Email = "sara@example.com" },
                new { Id = 3, Name = "John", Email = "john@example.com" }
            };

            return Ok(users);
        }
        //        "ASP.NET Core Web API ka action method bohot kuch return kar sakta hai:
        //✔️ IActionResult(har type ka response) //flexible and recommended
        //✔️ ActionResult<T>(strongly typed + status)
        //✔️ String, object, list(auto JSON)
        //✔️ JsonResult(force JSON)
        //✔️ ContentResult(text/HTML)
        //✔️ FileResult(file download)
        //✔️ StatusCode(custom code)
        //✔️ BadRequest, NotFound, EmptyResult waghera"
    }
    
}


