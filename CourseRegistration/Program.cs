using CourseRegistration;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<StudentRegistrationContext>(options => options.UseSqlServer(@"Server=localhost,1433;Database=CourseRegistrationDB;Persist Security Info=False;User ID=SA;Password=Dardha2@;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;"));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//1.Create an ASP.NET Core project named "RestaurantAPI" and use the ASP.NET Core CLI to install the required dependencies.
//2. Add the following lines of code to the Startup.cs file: using System; using System.IO; using System.Threading.Tasks; using Microsoft.AspNetCore.Builder; using Microsoft.AspNetCore.Hosting; using Microsoft.AspNetCore.Http; using Microsoft.AspNetCore.Mvc; using Microsoft.RestaurantAPI.Models; using Microsoft.RestaurantAPI.Services;
//3.Add a controller named "RestaurantController" to the project, and add the following code to the file: public class RestaurantController : Controller { public IActionResult Index() { return View(); } public IActionResult Create() { return View(); } public IActionResult Update(MenuItem menuItem) { return View(); } public IActionResult Delete(int id) { return View(); } public IActionResult Reservations(string name, DateTime date) { return View(); } }
//4.Add the following lines of code to the file to create a model named "MenuItem" and a service named "RestaurantAPI" to the project: public class MenuItem { public int Id { get; set; } public string Name { get; set; } public decimal Price { get; set; } }
//5.Add the following lines of code to the file to create a model named "Reservation" and a service named "RestaurantAPI" to the project: public class Reservation { public int Id { get; set; } public string Name { get; set; } public DateTime Date { get; set; } }
//6.Add the following lines of code to the file to create a route for GET requests to the "MenuItems" endpoint: public class MenuItemsRoute : Route { public IActionResult Index() { return View(); } public IActionResult Create() { return View(); } public IActionResult Update(MenuItem menuItem) { return View(); } public IActionResult Delete(int id) { return View(); } public IActionResult Reservations(string name, DateTime date) { return View(); } }
//7.Add the following lines of code to the file to create a route for GET requests to the "Reservations" endpoint: public class ReservationsRoute : Route { public IActionResult Index() { return View(); } public IActionResult Create() { return View(); } public IActionResult Update(Reservation reservation) { return View(); }