using DartsScorer.Web.Services;
using DartsScorer.Web.Services.Development;
using MongoDB.Driver;
using Serilog;
using Serilog.Sinks.MongoDB;

/// <summary>
/// Entry point for the Darts Scorer Web application.
/// Configures services and the HTTP request pipeline.
/// </summary>
/// <param name="args">Command-line arguments.</param>
var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.MongoDB(builder.Configuration["MongoDB:ConnectionString"], collectionName: "Logs")
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IRoundTheBoardService, MongoRoundTheBoardService>();
builder.Services.AddScoped<IPlayerService, MongoPlayerService>();
builder.Services.AddScoped<IX01Service, MongoX01Service>();

var mongoSettings = builder.Configuration.GetSection("MongoDB");
var mongoClient = new MongoClient(mongoSettings["ConnectionString"]);
builder.Services.AddSingleton<IMongoClient>(mongoClient);

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

// Add global error handling middleware
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        // Log the exception using Serilog
        Log.Error(ex, "Unhandled exception occurred");

        // Set the response status code and content
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
    }
});

// Ensure Serilog is flushed on application shutdown
app.Lifetime.ApplicationStopped.Register(Log.CloseAndFlush);

//app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
