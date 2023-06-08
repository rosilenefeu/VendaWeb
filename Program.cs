using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using VendaWebMvc.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

/*options.UseSqlServer(builder.Configuration.GetConnectionString("VendaWebMvcContext") ??
throw new InvalidOperationException("Connection string 'VendaWebMvcContext' not found.")));*/

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VendaWebMvcContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("VendaWebMvcContext"),
    new MySqlServerVersion(new Version())));
//, builder => builder.MigrationsAssembly("VendaWebMvc")


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
