using Microsoft.AspNetCore.Mvc;

namespace FlowerShopNew.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
