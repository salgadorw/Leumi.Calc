using Leumi.Calc.Domain.Core.Models;

namespace Leumi.Calc.Domain.Core.Repositories
{
    public interface ICalcValuesRepository
    {
        Guid AddCalcValues(CalcValuesModel calcValues);
        void DeleteCalcValue(Guid id);
        CalcValuesModel GetCalcValues(Guid id);
        void UpdateCalcValues(CalcValuesModel calcValues);
    }
}