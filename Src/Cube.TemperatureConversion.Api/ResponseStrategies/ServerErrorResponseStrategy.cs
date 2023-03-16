using System;
using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Cube.Temperature.Conversion.Api.ResponseStrategies
{
    public class ServerErrorResponseStrategy : IResponseStrategy
    {
        public IActionResult CreateResponse(ServiceResponse response) =>
            // In this example I'm hard coding a message.  Wouldnt normally do this.
            new ObjectResult("Oops something went wrong")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

        public bool IsMatch(ServiceResponse response) => response.Status.Equals(ResponseStatus.Exception) && response.Data.GetType() == typeof(ServiceException);
    }
}

