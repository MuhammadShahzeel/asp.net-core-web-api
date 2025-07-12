using Microsoft.AspNetCore.Mvc;

namespace _4Middlewares.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        // GET api/hello
        [HttpGet]
        public string Hello()
        {
            return " Hello from Controller!";
        }
    }
}
