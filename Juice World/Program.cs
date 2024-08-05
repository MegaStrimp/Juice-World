using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Juice_World.Data;
using Juice_World.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Juice_WorldContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Juice_WorldContext") ?? throw new InvalidOperationException("Connection string 'Juice_WorldContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

#region SeedData Setup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
