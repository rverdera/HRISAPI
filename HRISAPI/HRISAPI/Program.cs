
#region Namespaces
global using HRISAPI.Data;

global using HRISAPI.Contracts;
global using HRISAPI.Contracts.FM;
global using HRISAPI.Contracts.PDS;
global using HRISAPI.Contracts.UTILITY;
global using HRISAPI.Contracts.Service;

global using HRISAPI.Models;
global using HRISAPI.Models.FM;
global using HRISAPI.Models.PDS;
global using HRISAPI.Models.UTILITY;

global using HRISAPI.DTO.UTILITY;

global using HRISAPI.Repositories;
global using HRISAPI.Repositories.FM;
global using HRISAPI.Repositories.PDS;
global using HRISAPI.Repositories.UTILITY;

global using HRISAPI.Services;

global using Microsoft.EntityFrameworkCore;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Authorization;
global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations.Schema;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Security.Claims;
global using System.IdentityModel.Tokens.Jwt;
global using System.Text;

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

#endregion


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var secretToken = builder.Configuration.GetSection("AppSettings:MySecretKey").Value;

var validationParameters = new TokenValidationParameters
{
    ValidateAudience = false,
    ValidAudience = string.Empty,
    ValidateIssuer = false,
    ValidIssuer = string.Empty,
    ValidateIssuerSigningKey = true,
    ValidateLifetime = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretToken))
};

builder.Services.AddControllers();
builder.Services.AddDbContext<HRISDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ITokenService>(s => new TokenService(validationParameters, secretToken));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICivilStatusRepository, CivilStatusRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "HRS API",
        Description = "Human Resources System Web API"
    });
    
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(op =>
    {
        op.TokenValidationParameters = validationParameters;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
