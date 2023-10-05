using FlowerShopNew.Data.Contexts;
using FlowerShopNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowerShopNew.Controllers
{
    public class FrontProductController : Controller
    {
        private readonly AppDbContext appDbContext;
       

        public FrontProductController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
    
        }
        public IActionResult Index() 
        {
            var products = appDbContext.Products.ToList();
            return View(products);
        }
    }
}
