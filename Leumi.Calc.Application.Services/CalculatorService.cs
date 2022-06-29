using AutoMapper;
using Leumi.Calc.Application.Services.Dtos;
using Leumi.Calc.Domain.Core.Models;
using Leumi.Calc.Domain.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Leumi.Calc.Application.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IMemoryRepository repository;
        private readonly ILogger log;
        private readonly IHttpContextAccessor httpContext;
        public CalculatorService(IMemoryRepository memoryRepository, ILogger<CalculatorService> logger, IHttpContextAccessor httpContext )
        {
            this.repository = memoryRepository;
            this.log = logger;
            this.httpContext = httpContext;
        }

        public double Sum(CalcValues values)
        {
            LogClaims();
            return values.ValueA + values.ValueB;
        }

        public double Substract(CalcValues values)
        {
            return values.ValueA * values.ValueB;
        }

        public double Divide(CalcValues values)
        {

            return values.ValueA / values.ValueB;
        }

        public double Multiply(CalcValues values)
        {
            return values.ValueA * values.ValueB;
        }

        public void AddMemoryValue(double value)
        {
            repository.AddMemoryValue(value);
        }

        public double GetMemoryValue()
        {
           return repository.GetMemoryValue();
        }

        public void DeleteMemoryValue()
        {
            repository.DeleteMemoryValue();
        }


        private void LogClaims()
        {
            log.LogInformation(string.Join(',', httpContext.HttpContext.User.Claims));
        }

    }


}
