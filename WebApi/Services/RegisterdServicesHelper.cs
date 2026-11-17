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
using WebApi.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Services
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

           var jwtSettings = builder.Configuration
             .GetSection("Jwt")
             .Get<JwtSettings>()
             ?? throw new InvalidOperationException("JWT settings are missing.");

            if (Encoding.UTF8.GetByteCount(jwtSettings.SecretKey) < 32)
                throw new InvalidOperationException("JWT SecretKey must be at least 32 bytes.");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.SlidingExpiration = true;
            });

            var loggerConfiguration = new LoggerConfiguration().WriteTo.Console();
            if (!builder.Environment.IsDevelopment() ||
                builder.Configuration.GetValue<bool>("Startup:WriteLogsToSql"))
            {
                loggerConfiguration.WriteTo.MSSqlServer(
                    connectionString: builder.Configuration.GetConnectionString("ShippingConnection"),
                    tableName: "Log",
                    autoCreateSqlTable: true);
            }

            Serilog.Log.Logger = loggerConfiguration.CreateLogger();
            builder.Host.UseSerilog();


            builder.Services.AddScoped(typeof(ITableRepository<>), typeof(TableRepository<>));
            builder.Services.AddScoped(typeof(IViewRepository<>), typeof(ViewRepository<>));
            builder.Services.AddScoped<IShippingType, ShippingTypeService>();
            builder.Services.AddScoped<ICity, CityService>();
            builder.Services.AddScoped<ICountry, CountryService>();
            builder.Services.AddScoped<ICarrier, CarrierService>();
            builder.Services.AddScoped<IPaymentMethod, PaymentMethodService>();
            builder.Services.AddScoped<ISetting, SettingService>();
            builder.Services.AddScoped<IShippment, ShippmentService>();
            builder.Services.AddScoped<IShippmentStatus, ShippmentStatusService>();
            builder.Services.AddScoped<ISubscriptionPackage, SubscriptionPackageService>();
            builder.Services.AddScoped<IUserReceiver, UserReceiverService>();
            builder.Services.AddScoped<IUserSebder, UserSebderService>();
            builder.Services.AddScoped<IUserSubscription, UserSubscriptionService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IRefreshTokens, RefreshTokenService>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(MappingProfile).Assembly);
            });

            builder.Services.Configure<JwtSettings>(
             builder.Configuration.GetSection("Jwt"));

        }
    }
}
