using Leumi.Calc.Domain.Core.Models;

namespace Leumi.Calc.Domain.Core.Repositories
{
    public interface IMemoryRepository
    {
        void AddMemoryValue(double value);
        void DeleteMemoryValue();
        double GetMemoryValue();
        
    }
}