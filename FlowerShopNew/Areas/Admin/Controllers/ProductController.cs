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
			List<Category> categories = appDbContext.Categories.ToList();
			ViewBag.Categories = categories;
			Product product = appDbContext.Products.Find(id);

			ProductUpdateVM vm = new ProductUpdateVM();
			vm.Id = product.Id;
			vm.ProductCode = product.ProductCode;
			vm.Name = product.Name;
			vm.Price = product.Price;
			vm.CategoryId = product.CategoryId;
			vm.Description = product.Description;
			vm.ImageUrl = product.ImageUrl;

			return View(vm);
		}


		[HttpPost]
		public async Task<IActionResult> UpdateProduct(ProductUpdateVM productUpdateVM)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}

			var urun = appDbContext.Products.Find(productUpdateVM.Id);
			if (urun != null)
			{
				urun.ProductCode = productUpdateVM.ProductCode;
				urun.Name = productUpdateVM.Name;
				urun.Description = productUpdateVM.Description;
				urun.Price = productUpdateVM.Price;

				if (productUpdateVM.File != null)
				{
					var filePath = Path.Combine(hostEnvironment.WebRootPath, "product-photos"); // birleştirdi
					if (!Directory.Exists(filePath))
					{
						Directory.CreateDirectory(filePath);
					}

					string fileExt = Path.GetExtension(productUpdateVM.File.FileName);
					string uniqueFilename = Guid.NewGuid().ToString() + fileExt;


					var tamDosyaAdi = Path.Combine(filePath, uniqueFilename);

					using (var dosyaAkisi = new FileStream(tamDosyaAdi, FileMode.Create))
					{
						await productUpdateVM.File.CopyToAsync(dosyaAkisi);
					}

					urun.ImageUrl = uniqueFilename;
				}

				urun.CategoryId = productUpdateVM.CategoryId;

				appDbContext.Update(urun);
				appDbContext.SaveChanges();

			}
            ViewBag.Categories = appDbContext.Categories.ToList();
            return RedirectToAction(nameof(Index));
        }
	}

}

