using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Authentication.Configurations;
using Authentication.Data;
using Authentication.Helper;
using Authentication.Models;
using Authentication.Repository;
using Authentication.Repository.Interface;
using Authentication.Services;
using Authentication.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Configure Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

// Configure JWT
var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("Jwt").Bind(jwtSettings);
builder.Services.AddSingleton(jwtSettings);

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<AllowAccess>, AllowAccessRepository>();
builder.Services.AddScoped<IRepository<Intern>, InternRepository>();
builder.Services.AddScoped<IRepository<Role>, RoleRepository>();

// Register function services
builder.Services.AddScoped<IUserSevice, UserService>();
builder.Services.AddScoped<IInternService, InternService>();
builder.Services.AddScoped<IAllowAccessService, AllowAccessService>();
builder.Services.AddScoped<IRoleService, RoleService>();

// Configure JWT Authentication
var jwtSetting = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
var seretKey = jwtSetting.Key;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(seretKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
