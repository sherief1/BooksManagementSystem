using BooksManagementSystem.Common;
using BooksManagementSystem.Common.Helpers;
using BooksManagementSystem.DataAccess;
using BooksManagementSystem.DataService;
using BooksManagementSystem.Interfaces;
using BooksManagementSystem.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenManager.secretKey)), // Make sure this matches the key in CreateToken
        ValidateIssuer = false, // Disable issuer validation
        ValidateAudience = false, // Disable audience validation
        ClockSkew = TimeSpan.Zero // Optional: Set to zero to avoid token expiration issues
    };
});



builder.Services.AddScoped<IBooksDSL, BooksDSL>();
builder.Services.AddScoped<IBooksRepo, BooksRepo>();
builder.Services.AddScoped<IBooksDAL, BooksDAL>();

builder.Services.AddScoped<IAuthorDSL, AuthorDSL>();
builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
builder.Services.AddScoped<IAuthorDAL, AuthorDAL>();

builder.Services.AddScoped<IUserDSL, UserDSL>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserDAL, UserDAL>();

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
app.UseAuthentication(); // Enable authentication middleware
app.UseAuthorization();
app.MapControllers();

app.Run();
