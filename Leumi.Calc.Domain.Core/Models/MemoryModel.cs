using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leumi.Calc.Domain.Core.Models
{
    
    public class MemoryModel
    {
        [Key]
       public double MemoryValue { get; set; }
    }
}
