using System;
using Cube.Temperature.Conversion.Core.Constants;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Cube.Temperature.Conversion.Core.Interfaces;

namespace Cube.Temperature.Conversion.Core.ConversionStrategies
{
	public class NoConversionStrategy : IConversionStrategy
    {

        public bool CanConvert(Entities.Conversion conversion) => conversion.From.Unit.Equals(conversion.To.Unit);

        public ServiceResponse CreateResponse(Entities.Conversion conversion)
        {
            conversion.To.Value = conversion.From.Value;
            conversion.ConvertedOn = DateTime.Now;
            return new ServiceResponse { Data = conversion, Status = ResponseStatus.Success };
        }
    }
}

