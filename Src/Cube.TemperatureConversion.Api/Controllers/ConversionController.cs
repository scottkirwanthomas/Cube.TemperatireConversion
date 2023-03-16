using System.ComponentModel.DataAnnotations;
using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Api.Models;
using Cube.Temperature.Conversion.Core.Enums;
using Cube.Temperature.Conversion.Core.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cube.Temperature.Conversion.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class ConversionController : ControllerBase
{
    private readonly ILogger<ConversionController> logger;
    private readonly IValidationService validationService;
    private readonly IMapperService mapperService;
    private readonly IConversionService conversionService;
    private readonly IResponseFactory responseFactory;

    public ConversionController(ILogger<ConversionController> logger
        , IValidationService validationService
        , IMapperService mapperService
        , IConversionService conversionService
        , IResponseFactory responseFactory)
    {
        this.logger = logger;
        this.validationService = validationService;
        this.conversionService = conversionService;
        this.mapperService = mapperService;
        this.responseFactory = responseFactory;
    }

    [HttpGet]
    [Route("temperature")]
    [AllowAnonymous]
    [SwaggerOperation(Summary="Converts a value from one temperature unit to another", Description = "Converts temperature values between Fahrenheit, Celsius and Kelvin.", OperationId = "ConvertTemp")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a value containing the converted temperature.", typeof(double))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "An error has occurred.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request has some incorrect data.")]
    public IActionResult GetConvert([FromHeader][SwaggerParameter(Required = true, Description = "Name of the person requesting the conversion")] string userName
        , [FromQuery][Required] ConversionRequest conversionRequest)
    {
        try
        {
            var validationResult = validationService.ValidateConversionRequest(userName, conversionRequest);
            if (!validationResult.Status.Equals(ResponseStatus.Success))
            {
                return responseFactory.CreateResponse(validationResult);
            }

            // If successful map to conversion entity;
            var conversion = mapperService.ToConversion(userName, conversionRequest);

            // Execute conversion
            var response = conversionService.Convert(conversion);

            // Create response

            return responseFactory.CreateResponse(response);
        }
        catch (Exception ex)
        {
            return responseFactory.CreateResponse(ex);
        }
    }
}

