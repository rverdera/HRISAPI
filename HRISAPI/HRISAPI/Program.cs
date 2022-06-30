
#region Namespaces
global using HRISAPI.Data;

global using HRISAPI.Contracts;
global using HRISAPI.Contracts.FM;
global using HRISAPI.Contracts.PDS;

global using HRISAPI.Models;
global using HRISAPI.Models.FM;
global using HRISAPI.Models.PDS;

global using HRISAPI.Repositories;

global using Microsoft.EntityFrameworkCore;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Authorization;
global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

#endregion


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var validationParameters = new TokenValidationParameters
{
    ValidateAudience = false,
    ValidateIssuer = false,
    ValidateIssuerSigningKey = true,
    ValidateLifetime = true,
    ValidIssuer = string.Empty,
    ValidAudience = string.Empty,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretTo"))
};

builder.Services.AddControllers();
builder.Services.AddDbContext<HRISDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(op =>
    {
        op.TokenValidationParameters = new TokenValidationParameters();
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
