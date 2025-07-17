using _12ConsumingWebApiInMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace _12ConsumingWebApiInMVC.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7020/api/StudentAPI/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<StudentModel> students = new List<StudentModel>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject
                <List<StudentModel>>(result);
                if (data != null)
                {
                    students = data;
                }

            }

     






            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(student);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        //edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            StudentModel std = new StudentModel();
          
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<StudentModel>(result);
                if (data != null)
                {
                    std = data;

                }
            }
          
            return View(std);
        }

        // POST: Edit Student
        [HttpPost]
        public IActionResult Edit(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(student);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(url + student.id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }




        [HttpGet]
        public IActionResult Details(int id)
        {
            StudentModel std = new StudentModel();

            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<StudentModel>(result);
                if (data != null)
                {
                    std = data;

                }
            }

            return View(std);
        }

        // GET: Delete (Confirmation)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            StudentModel student = new StudentModel();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<StudentModel>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

    
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
         
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }



    }
}
