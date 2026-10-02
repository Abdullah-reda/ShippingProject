using DAL.Contracts;
using DAL.DbContext;
using DAL.Repositories;
using DAL.UserModels;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShippingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingConnection")));

Serilog.Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(
      connectionString: builder.Configuration.GetConnectionString("ShippingConnection"),
      tableName: "Log",
      autoCreateSqlTable: true)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddScoped <ITableRepository<TbShippingType>, TableRepository<TbShippingType>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
