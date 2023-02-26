using CourseRegistration;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var connectionApiKey = builder.Configuration["ConnectionStrings:DefaultConnection"];

// Add services to the container.
builder.Services.AddControllersWithViews();





void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<StudentRegistrationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(connectionApiKey)));
}
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

