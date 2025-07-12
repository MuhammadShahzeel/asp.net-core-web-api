using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        //  GET: /api/hello or /api/Hello not case sensitive
        [HttpGet]
        public string SayHello()
        {
            return "Hello, World!";
        }
    }
}
