using System;
using Cube.Temperature.Conversion.Core.Constants;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Cube.Temperature.Conversion.Core.Interfaces;

namespace Cube.Temperature.Conversion.Core.ConversionStrategies
{
    public class KelvinToFarenheitStrategy : IConversionStrategy
    {

        public bool CanConvert(Entities.Conversion conversion) => conversion.From.Unit.Equals(ConversionUnit.Kelvin) && conversion.To.Unit.Equals(ConversionUnit.Fahrenheit);

        public ServiceResponse CreateResponse(Entities.Conversion conversion)
        {
            conversion.To.Value = ((conversion.From.Value - ConversionFactors.KelvinFactor) * ConversionFactors.CelsiusToFarenheit) + ConversionFactors.FarenheitFactor;
            conversion.ConvertedOn = DateTime.Now;
            return new ServiceResponse { Data = conversion, Status = ResponseStatus.Success };
        }

    }
}