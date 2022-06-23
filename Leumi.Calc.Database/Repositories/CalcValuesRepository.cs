using Leumi.Calc.Domain.Core.Models;
using Leumi.Calc.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leumi.Calc.Database.Repositories
{
    public class CalcValuesRepository : ICalcValuesRepository
    {
        private readonly DbContextCalc context;
        public CalcValuesRepository(DbContextCalc dbContext)
        {
            this.context = dbContext;
        }

        public Guid AddCalcValues(CalcValuesModel calcValues)
        {
            calcValues.Id = Guid.NewGuid();
            context.CalcValues.Add(calcValues);
            context.SaveChanges();
            return calcValues.Id;
        }

        public CalcValuesModel GetCalcValues(Guid id)
        {
            return context.CalcValues.Where(w => w.Id.Equals(id)).FirstOrDefault();
        }

        public void UpdateCalcValues(CalcValuesModel calcValues)
        {
            var entity = GetCalcValues(calcValues.Id);
            entity.ValueA = calcValues.ValueA;
            entity.ValueB = calcValues.ValueB;
            context.SaveChanges();
        }

        public void DeleteCalcValue(Guid id)
        {
            var entity = GetCalcValues(id);
            context.CalcValues.Remove(entity);
            context.SaveChanges();
        }


    }
}
