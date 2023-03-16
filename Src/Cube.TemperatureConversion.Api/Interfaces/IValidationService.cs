using System;
using Cube.Temperature.Conversion.Api.Models;
using Cube.Temperature.Conversion.Core.Entities;

namespace Cube.Temperature.Conversion.Api.Interfaces
{
	public interface IValidationService
	{

		ServiceResponse ValidateConversionRequest(string userName, ConversionRequest conversionRequest);
	}
}

