using BL.Contracts;
using BL.Mapping;
using BL.Services;
using DAL.Contracts;
using DAL.DbContext;
using DAL.Repositories;
using DAL.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Ui.Services;


namespace UI
{
    public class RegisterdServicesHelper
    {
        public static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ShippingContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
              .AddEntityFrameworkStores<ShippingContext>()
              .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.SlidingExpiration = true;
            });

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
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(MappingProfile).Assembly);
            });

        }
    }
}
