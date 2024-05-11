
using AutoSpare.Application;
using AutoSpare.Infrastructure;
using AutoSpare.Persistence;
using AutoSpare.WebAPI.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy =>
    {
        //WithOrigins içinə web səhifənin linki (linkləri) yazılacaq
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationRegistration();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = ( notBefore,  expires, securityToken,  validationParameters)=>expires!=null?expires>DateTime.UtcNow:false
    };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseExceptionHandler();
app.UseCors();
//app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
