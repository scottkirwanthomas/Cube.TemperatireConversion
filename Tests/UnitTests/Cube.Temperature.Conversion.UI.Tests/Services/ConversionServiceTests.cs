using System;
using Cube.TemperatureConversion.UI.Interfaces;
using Cube.TemperatureConversion.UI.Models;
using Cube.TemperatureConversion.UI.Services;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Cube.Temperature.Conversion.UI.Tests.Services
{
    /// <summary>
    /// Tests here are incomplete, this is indictive of what would be created.
    /// </summary>
    public class ConversionServiceTests
    {
        private Mock<HttpMessageHandler> httpMessageHandler;
        private IConversionService serviceUnderTest;
        private HttpClient httpClient;
        private ConversionServiceOptions options;
        private TemperatureUnitConversion request;

        [SetUp]
        public void Setup()
        {
            httpMessageHandler = new Mock<HttpMessageHandler>();
            httpClient = new HttpClient(httpMessageHandler.Object);
            options = new ConversionServiceOptions
            {
                BasePath = "basepath",
                UserName = "scott.thomas"
            };
            var mockOptions = new Mock<IOptions<ConversionServiceOptions>>();
            mockOptions.Setup(x => x.Value).Returns(options);
            serviceUnderTest = new ConversionService(httpClient, mockOptions.Object );
            request = new TemperatureUnitConversion();
        }

        [Test]
        public void WhenConstructConversionUrlIsCalled_ThenACorrectUrlIsReturned()
        {
            request.FromUnit = "Celsius";
            request.ToUnit = "Celsius";
            request.FromValue = 1;
            var expectedResult = "basepath?fromunit=Celsius&tounit=Celsius&value=1";

            var result = serviceUnderTest.ConstructConversionUrl(request);

            result.Should().Be(expectedResult);
                
        }

       
    }
}

