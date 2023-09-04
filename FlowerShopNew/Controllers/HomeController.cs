using FlowerShopNew.Data.Contexts;
using FlowerShopNew.Data.Entities;
using FlowerShopNew.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlowerShopNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //DatabaseContext context = new();
            //Urun urun1 = new Urun() 
            //{           
            //    Name = "Papatya",
            //    Price =1200
            //};
            //Urun urun2 = new Urun()
            //{
            //    Name = "Gül",
            //    Price = 2000
            //};


            //context.Products.Add(urun1);
            //context.Products.Add(urun2);

            //context.SaveChanges();
         
//UPDATE
       
            //DELETE
            //DatabaseContext context2 = new();
            //var deleted_urun = context2.Products.FirstOrDefault(x => x.Id == 3);  // firstordefault ve find aynı görev veriyi çekeriz bunlar yardımıyla ıd si 4 olanlardan ilkini getirir
            //context2.Products.Remove(deleted_urun);
            //context2.SaveChanges();

 
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}