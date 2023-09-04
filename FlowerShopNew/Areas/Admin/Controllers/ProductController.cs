using FlowerShopNew.Areas.Admin.Models;
using FlowerShopNew.Areas.Admin.Models.ViewModels;
using FlowerShopNew.Data.Contexts;
using FlowerShopNew.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace FlowerShopNew.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class ProductController : Controller
	{
		//AppDbContext appDbContext= new AppDbContext();
		private readonly AppDbContext appDbContext;
		private readonly IWebHostEnvironment hostEnvironment;

		public ProductController(AppDbContext appDbContext, IWebHostEnvironment hostEnvironment)
		{
			this.appDbContext = appDbContext;
			this.hostEnvironment = hostEnvironment;
		}
		public IActionResult Index()
		{
			var products = appDbContext.Products.ToList();
			return View(products);
		}
		[HttpGet]
		public IActionResult AddProduct()
		{
			List<Category> categories = appDbContext.Categories.ToList();
			ViewBag.Categories = categories;
			var productAddVM = new ProductAddVM();
			return View(productAddVM);

		
		}
		[HttpPost]
		public async Task<IActionResult> AddProduct(ProductAddVM productAddVM)
		{
			if (ModelState.IsValid)
			{
				var filePath = Path.Combine(hostEnvironment.WebRootPath, "product-photos"); // birleştirdi
				if (!Directory.Exists(filePath))
				{
					Directory.CreateDirectory(filePath);
				}
				var tamDosyaAdi = Path.Combine(filePath, productAddVM.File.FileName);

				using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
				{
					await productAddVM.File.CopyToAsync(dosyaAkisi);

				} //garbagec beklemedeen kaynağı yok eder

				productAddVM.ImageUrl = productAddVM.File.FileName;
				Product product = new Product
				{
					Name = productAddVM.Name,
					Price = productAddVM.Price,
					CategoryId = productAddVM.CategoryId,
					ImageUrl = productAddVM.ImageUrl,
					Description = productAddVM.Description,
					File = productAddVM.File,
					ProductCode = productAddVM.ProductCode,
					Id = productAddVM.Id,


				};
				appDbContext.Add(product);
				appDbContext.SaveChanges();


				return RedirectToAction(nameof(Index));
			}
		
			ViewBag.Categories = appDbContext.Categories.ToList();

			return View();



		}

		[HttpGet]
		public IActionResult DeleteProduct()
		{
			return View();
		}

		[HttpPost]
		public IActionResult DeleteProduct(int id)
		{
			try
			{
				var urun = appDbContext.Products.Find(id);
				appDbContext.Products.Remove(urun);
				appDbContext.SaveChanges();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

			return Ok();

		}

		[HttpGet]
		public IActionResult UpdateProduct(int id)
		{
			Product product = appDbContext.Products.Find(id);

			return View(product);
		}


		[HttpPost]
		public IActionResult UpdateProduct(Product product)
		{
			var urun = appDbContext.Products.Find(product.Id);
			urun.Name = product.Name;
			urun.Price = product.Price;
			urun.Description = product.Description;
			urun.ProductCode = product.ProductCode;

			appDbContext.Products.Update(urun);
			appDbContext.SaveChanges();

			return RedirectToAction("Index");
		}

		






	}

}

