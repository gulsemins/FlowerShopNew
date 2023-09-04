using FlowerShopNew.Areas.Admin.Models;
using FlowerShopNew.Data.Contexts;
using FlowerShopNew.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Configuration;

namespace FlowerShopNew.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly SignInManager<AppUser> signInManager;
		private readonly AppDbContext appDbContext;

		public UserController(
			UserManager<AppUser> userManager,
			SignInManager<AppUser> signInManager,
			AppDbContext appDbContext)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.appDbContext = appDbContext;
		}

		[Authorize]
		public IActionResult Index()
		{
			return View(userManager.Users);
		}



		[HttpGet]
		public IActionResult Create()
		{
			List<AppUser> appUsers = appDbContext.Users.ToList();

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(UserRegisterModel UserRegisterModel)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser()
				{
					UserName = UserRegisterModel.UserName,
					Email = UserRegisterModel.Email

				};
				var result = await userManager.CreateAsync(appUser, UserRegisterModel.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Login");
				}
				else
				{
					result.Errors.ToList().ForEach(error => ModelState.AddModelError(error.Code, error.Description));
				}
			}

			return View();
		}

		#region LogIn
		[HttpGet]
		[Route("/Account/Login")]
		public IActionResult Login(string ReturnUrl)
		{
			TempData["returnUrl"] = ReturnUrl;
			return View();
		}

		[HttpPost]
		[Route("/Account/Login")]
		public async Task<IActionResult> Login(UserLoginModel userLoginModel)
		{
			if (ModelState.IsValid)
			{
				AppUser user = await userManager.FindByEmailAsync(userLoginModel.Email);
				if (user != null)
				{
					await signInManager.SignOutAsync();
					Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, userLoginModel.Password, userLoginModel.Persistent, userLoginModel.Lock);

					if (result.Succeeded)
					{
						return Redirect(TempData["returnUrl"].ToString());

					}
					else
					{
						ModelState.AddModelError("NotUser", "Böyle bir kullanıcı bulunmamaktadır.");
						ModelState.AddModelError("NotUser2", "E-posta veya şifre yanlış.");
					}
				}





			}
			return View();
		}

		#endregion
	}
}



