using Microsoft.AspNetCore.Mvc;

namespace FlowerShopNew.Controllers
{
    public class ProductConroller : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
    }
}
