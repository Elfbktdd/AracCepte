//using Microsoft.EntityFrameworkCore;
//using AracCepte.DataAccess.Context;
//using AracCepte.DataAccess.Abstract;
//using AracCepte.DataAccess.Repostories;
//using AracCepte.Business.Abstract;
//using AracCepte.Business.Concrete;
//using System.Reflection;
//<<<<<<< HEAD
//<<<<<<< HEAD
//using AracCepte.API.Mapping;
//=======
//=======
//>>>>>>> 5bf29c4be4a46d2ede2988fd635f811a4adeb4ac
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using AracCepte.DataAccess.Repositories;
//using AracCepte.Business.AuthService;
//<<<<<<< HEAD
//>>>>>>> 5bf29c4be4a46d2ede2988fd635f811a4adeb4ac
//=======
//>>>>>>> 5bf29c4be4a46d2ede2988fd635f811a4adeb4ac

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

////builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>) );
//builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>) );
//builder.Services.AddScoped<IUserRepository,UserRepository>();
//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddDbContext<AracCepteContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
//});
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});


//var jwtSettings = builder.Configuration.GetSection("Jwt");
//var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = true,
//        ValidIssuer = jwtSettings["Issuer"],
//        ValidateAudience = true,
//        ValidAudience = jwtSettings["Audience"],
//        ValidateLifetime = true,
//        ClockSkew = TimeSpan.Zero
//    };
//});
//builder.Services.AddControllers();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseCors("AllowAll");
//app.UseRouting();

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller = Home}/{action = HomePage}/{id?}"
//    );

//<<<<<<< HEAD
//<<<<<<< HEAD
//app.Run();
//builder.Services.AddAutoMapper(typeof(VehicleMapping));
//=======
//app.Run();
//>>>>>>> 5bf29c4be4a46d2ede2988fd635f811a4adeb4ac
//=======
//app.Run();
//>>>>>>> 5bf29c4be4a46d2ede2988fd635f811a4adeb4ac
using Microsoft.EntityFrameworkCore;
using AracCepte.DataAccess.Context;
using AracCepte.DataAccess.Abstract;
using AracCepte.DataAccess.Repositories;
using AracCepte.Business.Abstract;
using AracCepte.Business.Concrete;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AracCepte.Business.AuthService;
using AracCepte.DataAccess.Repostories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register repositories and services
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Configure database context
builder.Services.AddDbContext<AracCepteContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

// Swagger and API Documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// JWT Authentication configuration
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller = Home}/{action = HomePage}/{id?}"
);

app.Run();
