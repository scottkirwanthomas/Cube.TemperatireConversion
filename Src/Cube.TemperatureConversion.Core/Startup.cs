using Cube.Temperature.Conversion.Core.ConversionStrategies;
using Cube.Temperature.Conversion.Core.Factories;
using Cube.Temperature.Conversion.Core.Interfaces;
using Cube.Temperature.Conversion.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cube.Temperature.Conversion.Core
{
    public static class Startup
    {
        public static IServiceCollection ConfigureCore(this IServiceCollection services
            , ConfigurationManager configuration)
        {
            services.AddScoped<IConversionResponseFactory, ConversionResponseFactory>();
            services.AddScoped<IAuditService, AuditService>();
            services.AddScoped<IConversionService, ConversionService>();
            services.AddScoped<IConversionStrategy, CelsiusToFarenheitStrategy>();
            services.AddScoped<IConversionStrategy, CelsiusToKelvinStrategy>();
            services.AddScoped<IConversionStrategy, FahrenheitToCelsiusStrategy>();
            services.AddScoped<IConversionStrategy, FahrenheitToKelvinStrategy>();
            services.AddScoped<IConversionStrategy, KelvinToCelsiusStrategy>();
            services.AddScoped<IConversionStrategy, KelvinToFarenheitStrategy>();
            services.AddScoped<IConversionStrategy, NoConversionStrategy>();
            return services;
        }

    }
}

