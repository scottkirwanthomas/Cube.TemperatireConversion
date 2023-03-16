using System;
using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Cube.Temperature.Conversion.Api.Factories
{
    public class ResponseFactory : IResponseFactory
    {
        private readonly IEnumerable<IResponseStrategy> responses;

        public ResponseFactory(IEnumerable<IResponseStrategy> responses)
        {
            this.responses = responses;
        }

        public IActionResult CreateResponse(ServiceResponse serviceResponse)
        {
            return responses.Single(f => f.IsMatch(serviceResponse)).CreateResponse(serviceResponse);
        }

        public IActionResult CreateResponse(Exception exception)
        {
            return CreateResponse(new ServiceResponse()
            {
                Data = new ServiceException(exception),
                Status = ResponseStatus.Exception
            });
        }

    }
}



