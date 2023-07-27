using Microsoft.AspNetCore.Mvc;

namespace FlowerShopNew.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Faq() 
        {
            return View();
        }

        public IActionResult Location() 
        {
            return View();
        }

        public IActionResult Shop() 
        {
            return View();
        }
        public IActionResult ProductDetails() 
        {
            return View();
        }


       

      
    }
}
