using System;
using Cube.Temperature.Conversion.Api.Models;
using Entities = Cube.Temperature.Conversion.Core.Entities;

namespace Cube.Temperature.Conversion.Api.Interfaces
{
	public interface IMapperService
	{
        Entities.Conversion ToConversion(string userName, ConversionRequest conversionRequest);
	}
}

