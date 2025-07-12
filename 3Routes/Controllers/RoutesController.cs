using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace _3Routes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //you can also use 
    // [Route("api/[controller]/[action]")] // if you want to use action name in route



    public class RoutesController : ControllerBase
    {
        // 1️⃣ GET all → /api/Routes
        [HttpGet]
        public string GetAll()
        {
            return "📦 All items";
        }

        // 2️⃣ GET by ID → /api/Routes/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return $"📦 Item with ID: {id}";
        }

        // 3️⃣ GET by name → /api/Routes/byname/keyboard
        [HttpGet("byname/{name}")]
        public string GetByName(string name)
        {
            return $"🔍 Item name: {name}";
        }

        // 4️⃣ GET with optional ID → /api/Routes/search or /api/Routes/search/10
        [HttpGet("search/{id?}")]
        public string Search(int? id)
        {
            return $"🔎 Searched for ID: {id ?? 0}";
        }

        // 5️⃣ GET with multiple route parameters → /api/Routes/2/item/5
        [HttpGet("{categoryId}/item/{itemId}")]
        public string GetItemInCategory(int categoryId, int itemId)
        {
            return $"📁 Category {categoryId} → Item {itemId}";
        }
        //6 GET with multiple 
        [HttpGet("[action]")]// -> /api/Routes/Hey  same name as method
        public string Hey()
        {
            return "with action";
        }

        //7 another case
        //        Tumhara[Route("api/[controller]")] prefix sab par lagta hai normally.

        //Lekin agartarah[HttpGet("~/about")] → pura /about route banata hai app ke root se. yeh prefix ignore karega 

        [HttpGet("~/about")]
        public string About()
        {
            return "This is About page at /about";
        }
    }
}
