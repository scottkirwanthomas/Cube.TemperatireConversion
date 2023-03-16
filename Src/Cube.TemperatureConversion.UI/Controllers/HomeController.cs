using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cube.TemperatureConversion.UI.Models;
using Cube.TemperatureConversion.UI.Enums;
using Cube.TemperatureConversion.UI.Interfaces;

namespace Cube.TemperatureConversion.UI.Controllers;

public class HomeController : Controller
{
    private readonly IConversionService conversionService;
    private TemperatureUnitConversion temperatureConversion;

    public HomeController(IConversionService conversionService)
    {
        this.conversionService = conversionService;

        // Set default values for conversion page
        temperatureConversion = new TemperatureUnitConversion {
            FromUnit = TemperatureUnit.Celsius.ToString(),
            ToUnit = TemperatureUnit.Kelvin.ToString(),
            FromValue = 1 };
    }

    public IActionResult Index()
    {
        return View(temperatureConversion);
    }

    public async Task<OkObjectResult> Convert([FromQuery]TemperatureUnitConversion conversionRequest)
    {
        var result =  new OkObjectResult(await conversionService.ConvertAsync(conversionRequest));
        return result;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

