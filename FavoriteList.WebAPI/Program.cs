using FavoriteList.WebAPI.Repositories;
using FavoriteList.WebAPI.Services;
using FavortieList.WebAPI.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddTransient<FavListRepository>();
builder.Services.AddTransient<FavListService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.MapControllers();

app.Run();
