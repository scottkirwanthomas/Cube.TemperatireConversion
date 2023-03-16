using System;
using Cube.Temperature.Conversion.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cube.Temperature.Conversion.Api.Interfaces
{
    public interface IResponseFactory
    {
        IActionResult CreateResponse(ServiceResponse serviceResponse);

        IActionResult CreateResponse(Exception exception);
    }
}

