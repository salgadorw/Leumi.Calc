using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leumi.Calc.Domain.Core.Models
{
    
    public class CalcValuesModel
    { 
        public Guid Id { get; set; }

        public double ValueA { get; set; }

        public double ValueB { get; set; }
    }
}
