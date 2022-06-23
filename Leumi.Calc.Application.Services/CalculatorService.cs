using AutoMapper;
using Leumi.Calc.Application.Services.Dtos;
using Leumi.Calc.Domain.Core.Models;
using Leumi.Calc.Domain.Core.Repositories;

namespace Leumi.Calc.Application.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalcValuesRepository repository;
        private readonly IMapper mapper;
        public CalculatorService(ICalcValuesRepository calcValuesRepository, IMapper mapper)
        {
            this.repository = calcValuesRepository;
            this.mapper = mapper;
        }

        public double ExecuteCalculation(Guid calcValuesId, CalcOperationEnum calcOperation)
        {
            var values = repository.GetCalcValues(calcValuesId);
            double result = 0;
            switch (calcOperation)
            {
                case CalcOperationEnum.sum:
                    result = values.ValueA + values.ValueB;
                    break;
                case CalcOperationEnum.substract:
                    result = values.ValueA - values.ValueB;
                    break;
                case CalcOperationEnum.mutiply:
                    result = values.ValueA * values.ValueB;
                    break;
                case CalcOperationEnum.divide:
                    if (values.ValueB == 0)
                        throw new DivideByZeroException();
                    result = values.ValueA / values.ValueB;
                    break;

            }
            return result;
        }

        public Guid InsertCalcValues(CalcValues values)
        {

            return repository.AddCalcValues(mapper.Map<CalcValuesModel>(values));
        }

        public void Update(CalcValues values)
        {

            repository.UpdateCalcValues(mapper.Map<CalcValuesModel>(values));
        }
        public void Update(CalcValuesPath updatePart)
        {
            var entity = repository.GetCalcValues(updatePart.ValuesId);

            switch (updatePart.PropertyName)
            {
                case CalcValuesPath.PropertyNameEnum.ValueAEnum:
                    entity.ValueA = updatePart.Value;
                    break;
                case CalcValuesPath.PropertyNameEnum.ValueBEnum:
                    entity.ValueB = updatePart.Value;
                    break;               

            }

            repository.UpdateCalcValues(entity);
        }

        public void DeleteCalcValue(Guid id)
        {
            repository.DeleteCalcValue(id);
        }

    }


}
