using System;
using Cube.Temperature.Conversion.Core.Constants;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Cube.Temperature.Conversion.Core.Interfaces;

namespace Cube.Temperature.Conversion.Core.ConversionStrategies
{
    public class FahrenheitToKelvinStrategy : IConversionStrategy
    {
        public bool CanConvert(Entities.Conversion conversion) => conversion.From.Unit.Equals(ConversionUnit.Fahrenheit) && conversion.To.Unit.Equals(ConversionUnit.Kelvin);

        public ServiceResponse CreateResponse(Entities.Conversion conversion)
        {
            conversion.To.Value = ((conversion.From.Value - ConversionFactors.FarenheitFactor) * ConversionFactors.FarenheitToCelsius) + ConversionFactors.KelvinFactor;
            conversion.ConvertedOn = DateTime.Now;
            return new ServiceResponse { Data = conversion, Status = ResponseStatus.Success };
        }

    }
}