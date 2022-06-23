using AutoMapper;
using Leumi.Calc.Application.Services.Dtos;
using Leumi.Calc.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leumi.Calc.Application.Services.MappingProfile
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<CalcValues, CalcValuesModel>().ReverseMap();
        }
    }
}
