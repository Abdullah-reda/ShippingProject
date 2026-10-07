using BL.Mapping;
using DAL.DbContext;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ShippingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingConnection")));

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(
      connectionString: builder.Configuration.GetConnectionString("ShippingConnection"),
      tableName: "Log",
      autoCreateSqlTable: true)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(MappingProfile).Assembly);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
