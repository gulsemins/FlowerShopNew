using Microsoft.AspNetCore.Mvc;

namespace FlowerShopNew.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()

        {
            return View();
        }
    }
}
