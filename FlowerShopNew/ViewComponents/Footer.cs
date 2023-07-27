using Microsoft.AspNetCore.Mvc;

namespace FlowerShopNew.ViewComponents
{
    public class Footer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        } 
    }
}
