using System;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Cube.Temperature.Conversion.Core.Interfaces;

namespace Cube.Temperature.Conversion.Core.Factories
{
	public class ConversionResponseFactory: IConversionResponseFactory
	{
        private readonly IEnumerable<IConversionStrategy> responses;

		public ConversionResponseFactory(IEnumerable<IConversionStrategy> responses)
		{
            this.responses = responses;
		}

        public ServiceResponse CreateResponse(Entities.Conversion conversion)
        {
            return responses.Single(f => f.CanConvert(conversion)).CreateResponse(conversion);
        }

        public ServiceResponse CreateResponse(Exception exception)
        {
            return new ServiceResponse {
                Status = ResponseStatus.Exception,
                Data = new ServiceException(exception)
            };
        }
    }
}

