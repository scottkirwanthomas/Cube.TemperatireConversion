using System;
using Swashbuckle.AspNetCore.Annotations;

namespace Cube.Temperature.Conversion.Api.Models
{
	public class ConversionRequest
	{
		[SwaggerParameter(Required = true, Description = "Represents the unit to convert from has to be one of the following:<br/><br/> <ul><li>Fahrenheit</li><li>Celsius</li><li>Kelvin</li></ul>")]
		public string FromUnit { get; set; }
        [SwaggerParameter(Required = true, Description = "Represents the unit to convert to has to be one of the following:<br/><br/> <ul><li>Fahrenheit</li><li>Celsius</li><li>Kelvin</li></ul>")]
        public string ToUnit { get; set; }
        [SwaggerParameter(Required = true, Description = "Represents the value of the unit to convert from")]
        public double Value { get; set; }
	}
}

