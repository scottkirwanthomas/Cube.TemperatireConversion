using System;
using Cube.TemperatureConversion.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cube.TemperatureConversion.UI.Interfaces
{
    public interface IConversionService
    {
        Task<ServiceResponse<double>> ConvertAsync(TemperatureUnitConversion request);

        string ConstructConversionUrl(TemperatureUnitConversion request);

    }
}

