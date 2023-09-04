using FlowerShopNew.CustomValidations;
using FlowerShopNew.Data.Contexts;
using FlowerShopNew.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("SqlServerConnectionString");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddIdentity<AppUser, AppRole>(config =>
{
    config.Password.RequiredLength = 5;
    config.Password.RequireLowercase = false;
    config.Password.RequireUppercase = false;
    config.Password.RequireDigit = false;

    config.User.RequireUniqueEmail = true; 
    config.User.AllowedUserNameCharacters = "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+";

}).AddEntityFrameworkStores<AppDbContext>().AddPasswordValidator<CustomPasswordValidation>().AddUserValidator<CustomUserValidation>().AddErrorDescriber<CustomIdentityErrorDescriber>();

builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});



//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
