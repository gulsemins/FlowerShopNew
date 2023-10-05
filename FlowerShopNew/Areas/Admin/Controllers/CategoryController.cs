using FlowerShopNew.Areas.Admin.Models;
using FlowerShopNew.Data.Contexts;
using FlowerShopNew.Data.Entities;
using FlowerShopNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace FlowerShopNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        //AppDbContext appDbContext= new AppDbContext();
        private readonly AppDbContext appDbContext;
        private readonly IWebHostEnvironment hostEnvironment;

        public CategoryController(AppDbContext appDbContext, IWebHostEnvironment hostEnvironment)
        {
            this.appDbContext = appDbContext;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var degerler = appDbContext.Categories.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            appDbContext.Categories.Add(category);
            appDbContext.SaveChanges();
            return RedirectToAction("Index");

           
        }
        [HttpGet]
        public IActionResult DeleteCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {

            try
            {
                var ctg = appDbContext.Categories.Find(id);
                appDbContext.Categories.Remove(ctg);
                appDbContext.SaveChanges();
              
            }

			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

			return Ok();
		}

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            Category category = appDbContext.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {

			try
			{
				var ctg = appDbContext.Categories.Find(category.Id);
				if (ctg != null)
				{
					ctg.Name = category.Name;
					ctg.OrderNr = category.OrderNr;
					ctg.IsActive = category.IsActive;
                    

					appDbContext.Categories.Update(ctg);
					appDbContext.SaveChanges();

					return RedirectToAction("Index");
				}
				else
				{
					// Handle the case where the category with the specified ID was not found.
					// You can return a specific view or message here.
					return NotFound();
				}
			}
			catch (Exception ex)
			{
				// Log the exception or handle it appropriately
				return StatusCode(500, ex.Message);
			}

			//         var ctg = appDbContext.Categories.Find(category.Id);
			//         ctg.Name = category.Name;
			//         ctg.OrderNr = category.OrderNr;
			//         ctg.IsActive = category.IsActive;

			//appDbContext.Categories.Update(ctg);
			//appDbContext.SaveChanges();

			//return RedirectToAction("Index");

		}

    }
}

