using System;
using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Api.Models;
using Entities = Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;

namespace Cube.Temperature.Conversion.Api.Services
{
    public class MapperService : IMapperService
    {
        public Entities.Conversion ToConversion(string userName, ConversionRequest conversionRequest)
        {
            return new Entities.Conversion
            {
                UserName = userName,
                From = new Entities.UnitValue
                {
                    Value = conversionRequest.Value,
                    Unit = (ConversionUnit)Enum.Parse(typeof(ConversionUnit), conversionRequest.FromUnit,true)
                },
                To = new Entities.UnitValue
                {
                    Unit = (ConversionUnit)Enum.Parse(typeof(ConversionUnit), conversionRequest.ToUnit, true)
                }
            };
        }
    }
}

