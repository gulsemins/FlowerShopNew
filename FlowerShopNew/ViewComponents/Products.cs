using FlowerShopNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShopNew.ViewComponents
{
    public class Products : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }

    }
}
