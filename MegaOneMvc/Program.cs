using MediatR;
using MegaOneMvc.Abstractions.Repositories;
using MegaOneMvc.Abstractions.Services;
using MegaOneMvc.DAL;
using MegaOneMvc.Models.Entities;
using MegaOneMvc.Repositories;
using MegaOneMvc.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
builder.Services.AddScoped<IBaseRepository<Deal>, BaseRepository<Deal>>();
builder.Services.AddScoped<IBaseRepository<Food>, BaseRepository<Food>>();
builder.Services.AddScoped<IBaseRepository<Booking>, BaseRepository<Booking>>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 6;
    opt.User.RequireUniqueEmail = true;

}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
