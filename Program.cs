using Microsoft.EntityFrameworkCore;
using AdventureCore.Data;
using Microsoft.Extensions.Options;
using AdventureCore.Repositories;
using AdventureCore.Repositories.Interfaces;
using AdventureCore.Repositories.Implementations;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddMvc();

builder.Services.AddDbContext<ContextoAdventure>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("Miconexion")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();


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
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
