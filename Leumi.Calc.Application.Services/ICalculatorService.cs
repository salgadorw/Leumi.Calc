
using Leumi.Calc.Application.Services.Dtos;

namespace Leumi.Calc.Application.Services
{
    public interface ICalculatorService
    {
        void DeleteCalcValue(Guid id);
        double ExecuteCalculation(Guid calcValuesId, CalcOperationEnum calcOperation);
        Guid InsertCalcValues(CalcValues values);
        void Update(CalcValues values);
        void Update(CalcValuesPath updatePart);
    }
}