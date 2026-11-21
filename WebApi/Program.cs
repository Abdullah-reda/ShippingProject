using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7067") // 👈 Your MVC project URL
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // 👈 Required for cookies (refresh token)
    });
});

// Services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

RegisterdServicesHelper.RegisterServices(builder);

var app = builder.Build();

if (!app.Environment.IsDevelopment() ||
    app.Configuration.GetValue<bool>("Startup:RunIdentitySeeder"))
{
    using var scope = app.Services.CreateScope();
    await IdentitySeeder.SeedAsync(scope.ServiceProvider, app.Configuration);
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
