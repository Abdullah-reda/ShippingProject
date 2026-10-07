using BL.Contracts;
using BL.Mapping;
using BL.Services;
using DAL.Contracts;
using DAL.DbContext;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace UI
{
    public class RegisterdServicesHelper
    {
        public static void RegisterServices(WebApplicationBuilder builder)
        {
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


            builder.Services.AddScoped(typeof(ITableRepository<>), typeof(TableRepository<>));
            builder.Services.AddScoped<IShippingType, ShippingTypeService>();
            builder.Services.AddScoped<ICity, CityService>();
            builder.Services.AddScoped<ICountry, CountryService>();
            builder.Services.AddScoped<ICarrier, CarrierService>();
            builder.Services.AddScoped<ILog, LogService>();
            builder.Services.AddScoped<IPaymentMethod, PaymentMethodService>();
            builder.Services.AddScoped<ISetting, SettingService>();
            builder.Services.AddScoped<IShippment, ShippmentService>();
            builder.Services.AddScoped<IShippmentStatus, ShippmentStatusService>();
            builder.Services.AddScoped<ISubscriptionPackage, SubscriptionPackageService>();
            builder.Services.AddScoped<IUserReceiver, UserReceiverService>();
            builder.Services.AddScoped<IUserSebder, UserSebderService>();
            builder.Services.AddScoped<IUserSubscription, UserSubscriptionService>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(MappingProfile).Assembly);
            });

        }
    }
}
