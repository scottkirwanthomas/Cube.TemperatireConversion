using System;
using Cube.Temperature.Conversion.Core.Entities;

namespace Cube.Temperature.Conversion.Core.Interfaces
{
	public interface IConversionService
	{
		ServiceResponse Convert(Entities.Conversion conversionToRun); 
	}
}

