using Leumi.Calc.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.EntityFrameworkCore;
using Leumi.Calc.Application.Services;
using Leumi.Calc.Domain.Core.Repositories;
using Leumi.Calc.Database.Repositories;
using Leumi.Calc.Application.Services.MappingProfile;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
var serviceProvider = builder.Services.BuildServiceProvider();
var beareScheme = JwtBearerDefaults.AuthenticationScheme;
//Database
builder.Services.AddDbContext<DbContextCalcMemory>(op => op.UseInMemoryDatabase("LeumiCalc"));
//ConfigureDependencies
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IMemoryRepository, MemoryRepository>();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();

//Add authentication
builder.Services
    .AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = beareScheme;
options.DefaultChallengeScheme = beareScheme;
})
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = builder.Configuration["AuthSettings:Audience"],
                ValidIssuer = builder.Configuration["AuthSettings:Issuer"],
                RequireExpirationTime = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:key"])),
                ValidateIssuerSigningKey = true,

            };
        });

//API
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.IncludeXmlComments(System.AppDomain.CurrentDomain.BaseDirectory + "Leumi.Calc.Api.xml", true);


    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Leumi Calc API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
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

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
}); 

app.Run();
