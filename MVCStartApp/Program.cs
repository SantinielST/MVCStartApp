using Microsoft.EntityFrameworkCore;
using MVCStartApp.DLL.Repository.Interfaces;
using MVCStartApp.Middlewares;
using MVCStartApp.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
string connect = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connect));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<LoggingMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
