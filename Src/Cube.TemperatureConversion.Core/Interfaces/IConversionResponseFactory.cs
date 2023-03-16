using System;
using Cube.Temperature.Conversion.Core.Entities;

namespace Cube.Temperature.Conversion.Core.Interfaces
{
	public interface IConversionResponseFactory
	{
		ServiceResponse CreateResponse(Entities.Conversion conversion);

		ServiceResponse CreateResponse(Exception exception);
	}
}

