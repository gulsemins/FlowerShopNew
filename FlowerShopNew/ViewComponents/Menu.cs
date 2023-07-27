using Microsoft.AspNetCore.Mvc;

namespace FlowerShopNew.ViewComponents
{
    public class Menu : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
