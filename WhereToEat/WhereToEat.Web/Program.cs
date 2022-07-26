using WhereToEat.Services.IServices;
using WhereToEat.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddMvc(); //Adds basic MVC functionality
builder.Services.AddControllers(); //Adds support for MVC controllers (views and routing would need to be added separately)
builder.Services.AddLogging(); //Adds default logging support
builder.Services.AddSignalR(); //Adds support for SignalR
builder.Services.AddTransient<IRestaurantService, RestaurantService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
