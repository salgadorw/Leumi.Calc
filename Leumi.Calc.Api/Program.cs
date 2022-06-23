using Leumi.Calc.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.EntityFrameworkCore;
using Leumi.Calc.Application.Services;
using Leumi.Calc.Domain.Core.Repositories;
using Leumi.Calc.Database.Repositories;
using Leumi.Calc.Application.Services.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

//Database
builder.Services.AddDbContext<DbContextCalc>(op => op.UseInMemoryDatabase("LeumiCalc"));
//ConfigureDependencies
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder.Services.AddScoped<ICalcValuesRepository, CalcValuesRepository>();
builder.Services.AddScoped<ICalculatorService,CalculatorService>();

//API
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.IncludeXmlComments(System.AppDomain.CurrentDomain.BaseDirectory+ "Leumi.Calc.Api.xml", true));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
