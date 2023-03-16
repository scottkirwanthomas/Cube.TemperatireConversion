using System;
using Cube.Temperature.Conversion.Api.Interfaces;
using Entities = Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Cube.Temperature.Conversion.Api.ResponseStrategies
{
    public class OkResponseStrategy : IResponseStrategy
    {

        public IActionResult CreateResponse(Entities.ServiceResponse response) => new OkObjectResult(response.Data)
        {
            StatusCode = StatusCodes.Status200OK
        };

        public bool IsMatch(Entities.ServiceResponse response) => response.Status.Equals(ResponseStatus.Success) && response.Data.GetType() == typeof(Entities.Conversion);
    }
}

