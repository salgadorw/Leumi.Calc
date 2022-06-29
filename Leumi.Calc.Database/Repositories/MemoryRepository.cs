using Leumi.Calc.Domain.Core.Models;
using Leumi.Calc.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leumi.Calc.Database.Repositories
{
    public class MemoryRepository : IMemoryRepository
    {
        private readonly DbContextCalcMemory context;
        public MemoryRepository(DbContextCalcMemory dbContext)
        {
            this.context = dbContext;
        }

       

        public void AddMemoryValue(double value)
        {
            context.Memory.Add(new MemoryModel { MemoryValue = value });
            context.SaveChanges();
        }

        public void DeleteMemoryValue()
        {
            var valueToRemove = context.Memory.FirstOrDefault();
            if (valueToRemove != null)
                context.Memory.Remove(valueToRemove);
            context.SaveChanges();

        }

        public double GetMemoryValue()
        {
            return context.Memory.FirstOrDefault()?.MemoryValue??0.0;
        }
    }
}
