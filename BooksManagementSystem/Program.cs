using BooksManagementSystem;
using BooksManagementSystem.authorization_for_special_users;
using BooksManagementSystem.Common;
using BooksManagementSystem.Common.Helpers;
using BooksManagementSystem.DataAccess;
using BooksManagementSystem.DataService;
using BooksManagementSystem.Interfaces;
using BooksManagementSystem.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
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

builder.Services.AddHttpContextAccessor();


// ---THE BASIC WAY--- //
//define policies based on roles. Update your authentication setup
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("BooksOnly", policy => policy.RequireClaim("Role", "Basic"));
//    options.AddPolicy("BooksAndAuthors", policy => policy.RequireClaim("Role", "Admin"));
//});
//-------------------------//


//authorization using policy (Session handler way)
//builder.Services.AddSingleton<IAuthorizationHandler, SessionHandler>(); // Register the handler
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("BasicRolePolicy", policy =>
//        policy.Requirements.Add(new SessionRequirement("Basic"))); // Policy for "Basic" role

//    options.AddPolicy("AdminRolePolicy", policy =>
//        policy.Requirements.Add(new SessionRequirement("Admin"))); // Policy for "Admin" role
//});

//authorization using policy for special users
builder.Services.AddScoped<IAuthorizationHandler, SpecialAccessHandler>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("BasicAccessPolicy", policy =>
    {
        policy.Requirements.Add(new SpecialAccessRequirement("Basic"));
    });
    options.AddPolicy("AdminAccessPolicy", policy =>
    {
        policy.Requirements.Add(new SpecialAccessRequirement("Admin"));
    });
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

builder.Services.AddScoped<ISpecialAccessUsersDAL, SpecialAccessUsersDAL>();
builder.Services.AddScoped<ISpecialAccessUsersRepo, SpecialAccessUsersRepo>();
builder.Services.AddScoped<ISpecialAccessUsersDSL, SpecialAccessUsersDSL>();

//builder.Services.AddScoped<CustomAuthorizeAttribute>(); //Way 1
//builder.Services.AddScoped<CAuthorizeAttribute>(); //Way 2


builder.Services.AddScoped<EncryptionHelper>();


// Register DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("myCon")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer <YOUR_TOKEN>' to access this API"
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


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
