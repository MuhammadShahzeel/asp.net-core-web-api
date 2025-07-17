using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace _10WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // Fruits list
        List<string> fruits = new List<string>
        {
            "Apple",
            "Banana",
            "Orange",
            "Mango",
            "Grapes",
            "Pineapple",
            "Strawberry",
            "Blueberry",
            "Watermelon",
            "Papaya",
            "Guava",
            "Kiwi",
            "Pomegranate"
        };

        // GET: api/Home
        [HttpGet]
        public List<string> GetFruits()
        {
            return fruits;
        }

        // GET: api/Home/{id}
        [HttpGet("{id}")]
        public string GetFruitByIndex(int id)
        {
            if (id < 0 || id >= fruits.Count)
            {
                return "Fruit not found";
            }
            return fruits[id];
        }
    }
}
