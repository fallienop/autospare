
using AutoSpare.Application;
using AutoSpare.Domain.Entities.Identity;
using AutoSpare.Infrastructure;
using AutoSpare.Persistence;
using AutoSpare.Persistence.Contexts;
using AutoSpare.WebAPI;
using AutoSpare.WebAPI.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


//builder.Services.AddIdentity<AppUser, AppRole>()
//    .AddEntityFrameworkStores<AutoSpareDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddTransient<SuperAdmin>();




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
    .AddJwtBearer(options =>
    //.AddJwtBearer("Admin",options =>
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

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    try
//    {
//        var superAdmin = services.GetRequiredService<SuperAdmin>();
//        await superAdmin.AddSuperAdmin();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"An error occurred: {ex.Message}");
//    }
//}

//await app.RunAsync();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseExceptionHandler();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
