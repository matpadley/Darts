using DartsScorer.Web.Services;
using DartsScorer.Web.Services.Development;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddScoped<IRoundTheBoardService, MongoRoundTheBoardService>();
    builder.Services.AddScoped<IPlayerService, MongoPlayerService>();
    builder.Services.AddScoped<IX01Service, MongoX01Service>();
} else {
    builder.Services.AddScoped<IRoundTheBoardService, RoundTheBoardService>();
    builder.Services.AddScoped<IPlayerService, PlayerService>();
    builder.Services.AddScoped<IX01Service, X01Service>();
}

// Add MongoDB configuration for production
if (!builder.Environment.IsDevelopment())
{
    var mongoSettings = builder.Configuration.GetSection("MongoDB");
    var mongoClient = new MongoClient(mongoSettings["ConnectionString"]);
    builder.Services.AddSingleton<IMongoClient>(mongoClient);
}

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

//app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
