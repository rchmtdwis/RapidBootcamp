using Microsoft.EntityFrameworkCore;
using RapidBootcamp.WebApplication.DAL;

var builder = WebApplication.CreateBuilder(args);

//menambahkan modul mvc
builder.Services.AddDbContext<AppDbContext>(options => 
{
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategory, CategoriesEF>();
builder.Services.AddScoped<ICustomer, CustomersEF>();
builder.Services.AddScoped<IProduct, ProductsEF>();


var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();

app.MapControllerRoute(
       name: "default",
       pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
