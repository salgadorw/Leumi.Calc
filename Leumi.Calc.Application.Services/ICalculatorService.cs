using Leumi.Calc.Application.Services.Dtos;

namespace Leumi.Calc.Application.Services
{
    public interface ICalculatorService
    {
        void AddMemoryValue(double value);
        void DeleteMemoryValue();
        double Divide(CalcValues values);
        double GetMemoryValue();
        double Multiply(CalcValues values);
        double Substract(CalcValues values);
        double Sum(CalcValues values);
    }
}