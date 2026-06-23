using ECom_udemy.Classes;
using ECom_db.Services;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .MinimumLevel.Verbose()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();
Log.Logger.Information("Starting up the application...");




// Add services to the container.
// الحل: الـ Db تقرأ الأول وبعدين الـ Api
builder.Services.AddInjectionOptionDb(builder.Configuration);
builder.Services.AddInjectionOptionApi();
Stripe.StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//UseExtensions swagger
//    instal Swashbuckle.AspNetCore

builder.Services.AddEndpointsApiExplorer(); //for swagger
builder.Services.AddSwaggerGen();//for swagger
//CORS config 
builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(options =>
    {
        options.AllowAnyHeader()
        .AllowAnyMethod()
        //.WithOrigins("https://localhost:27829");
        .AllowAnyOrigin();
    });
});
try
{
    var app = builder.Build();
    app.UseCors();
    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();//for swagger
        app.UseSwaggerUI();//for swagger
    }

    app.AddMiddleWareDb();//////////////////////////
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
    Log.Logger.Information("Application Try started successfully.");

    app.Run();
    Log.Logger.Information("Application started successfully.");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start.");
}
finally
{
    Log.Logger.Information("Application closed successfully.");
    Log.CloseAndFlush();
}
