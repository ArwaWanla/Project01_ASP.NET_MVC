using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using phoneStore.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace phoneStore.Controllers
{
    public class PhonesController : Controller
    {
        List<PhoneModel> Phones = new List<PhoneModel>();

        public PhonesController()//ctr
        {
            this.Phones.Add(new PhoneModel() { ID = 1, Name = "xiaomi", Image = "https://www.jarir.com/cdn-cgi/image/fit=contain,width=210,height=/https://www.jarir.com/media//catalog/product/5/5/557886.jpg?1", Price = 1799, details = "سعة 128 جيجابايت ،Lunar Silver ، الجيل الخامس 5G" });
            this.Phones.Add(new PhoneModel() { ID = 2, Name = "samsung Galaxy z", Image = "https://www.jarir.com/cdn-cgi/image/fit=contain,width=210,height=/https://www.jarir.com/media//catalog/product/5/5/554669.jpg?1", Price = 349, details = "غطاء خلفي للهاتف ،for (Samsung) Galaxy Z Fold2 ،اسود" });
            this.Phones.Add(new PhoneModel() { ID = 3, Name = "apple iphone 12", Image = "https://www.jarir.com/cdn-cgi/image/fit=contain,width=210,height=/https://www.jarir.com/media//catalog/product/5/5/556780.jpg?1", Price = 4499, details = "سعة 128 جيجابايت ،جرافيتي ، الجيل الخامس 5G" });
        }
       

        // GET: /<controller>/
        public IActionResult Index(string color = "")
        {
            //using (var client = new HttpClient())
            //{
            //    //Passing service base url  
            //    client.BaseAddress = new Uri(Baseurl);
            //    client.DefaultRequestHeaders.Clear();

            //    //Define request data format  
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            //    HttpResponseMessage Res = await client.GetAsync("api/Smartphones/Index");

            //    //Checking the response is successful or not which is sent using HttpClient  
            //    if (Res.IsSuccessStatusCode)
            //    {
            //        //Storing the response details recieved from web api   
            //        var PhonesResponse = Res.Content.ReadAsStringAsync().Result;

            //        //Deserializing the response recieved from web api and storing into the Employee list  
            //        var PhonesInfo = JsonConvert.DeserializeObject<List<SmartphoneModel>>(PhonesResponse);

            //    }

            //}

            ViewData["color"] = color;
            ViewData["Phones"] = Phones;
            return View();
        }

        // GET: /<controller>/

        public IActionResult Details(int id)
        {

            

           
            if (!Phones.ToList().Exists(p => p.ID == id))
            {

                return View(ErrorPage());



            }
            else
            {
                var phone = Phones.Find(b => b.ID == id);
                ViewData["phone"] = phone;


                return View();
            }
        }

        // GET: /<controller>/
        public IActionResult ErrorPage()
        {
            var message = "Not Found 404";
            ViewData["message"] = message;

            return View();
        }

    }
}
