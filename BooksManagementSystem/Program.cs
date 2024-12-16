using BooksManagementSystem.Data;
using BooksManagementSystem.DataAccess;
using BooksManagementSystem.DataService;
using BooksManagementSystem.Interfaces;
using BooksManagementSystem.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddScoped<IBooksDSL, BooksDSL>();
builder.Services.AddScoped<IBooksRepo, BooksRepo>();
builder.Services.AddScoped<IBooksDAL, BooksDAL>();

// Register DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("myCon")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
