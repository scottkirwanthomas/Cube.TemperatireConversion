using System;
using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Cube.Temperature.Conversion.Api.ResponseStrategies
{
	public class ValidationFailureResponseStrategy : IResponseStrategy
    {
        public IActionResult CreateResponse(ServiceResponse response) => new BadRequestObjectResult(response.Data)
        {

        };

        public bool IsMatch(ServiceResponse response) => response.Status.Equals(ResponseStatus.ValidationFailure);
    }
}

