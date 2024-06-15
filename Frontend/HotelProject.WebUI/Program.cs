using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>(); //Identity Register Ekleme Ýþlemleri Ýçin Yazýlan Attribute
builder.Services.AddDbContext<Context>(); //Identity Register Ekleme Ýþlemleri Ýçin Yazýlan Attribute

builder.Services.AddHttpClient(); //Api istekleri karþýla
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //mapleme



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
