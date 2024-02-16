using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using client.Data;
using client.Models;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<BetaxeContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DevBetaxeContext") ?? throw new InvalidOperationException("Connection string 'DevBetaxeContext' not found.")));
}
else
{
    builder.Services.AddDbContext<BetaxeContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProdDevBetaxeContext") ?? throw new InvalidOperationException("Connection string 'ProdDevBetaxeContext' not found.")));
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
