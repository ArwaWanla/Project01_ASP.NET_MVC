using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using phoneStore.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace phoneStore.Controllers
{
    public class BrandsController : Controller
    {
        List<BrandModel> Brands = new List<BrandModel>();
       
        public BrandsController()//ctr
        {

            this.Brands.Add(new BrandModel() { ID = 1, Name = "Apple", Logo = "https://images.unsplash.com/photo-1612994370726-5d4d609fca1b?ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8YXBwbGUlMjBsb2dvfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=700&q=60" , Products = "phones tablets speakers"} );
            this.Brands.Add(new BrandModel() { ID = 2, Name = "Xiaomi", Logo = "data:image/png;base64,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" , Products = "phones, tablets, head phones"} );
            this.Brands.Add(new BrandModel() { ID = 3, Name = "Samsung", Logo = "https://www.appspace.com/wp-content/uploads/2020/01/Samsung-logo-2015-640x480.png", Products = "phones ,tablets , head phones ,Watches" });
    
        }



        // GET: /<controller>/
        public IActionResult Index()
        {
            
            ViewData["Brands"] = Brands;
            
            return View();
        }

        public IActionResult Details(int? id)
        {
            var brand = Brands.Find(p => p.ID == id);

            if (brand == null)
            {
                return RedirectToAction("BrandErrorPage");
            }
            else
            {
                ViewData["brand"] = brand;
                return View();
            }
        }

        public IActionResult BrandError()
        {
            var message = "Not Found 404";
            ViewData["message"] = message;
            return View();
        }
    }
}
