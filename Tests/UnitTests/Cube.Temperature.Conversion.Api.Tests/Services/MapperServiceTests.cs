using System;
using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Api.Models;
using Cube.Temperature.Conversion.Api.Services;
using Entities = Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using FluentValidation;
using Moq;
using NUnit.Framework;
using FluentAssertions;

namespace Cube.Temperature.Conversion.Api.Tests.Services
{
	public class MapperServiceTests
	{
        private IMapperService serviceUnderTest;
        private ConversionRequest conversionRequest;
        private Entities.Conversion conversion;

        [SetUp]
        public void Setup()
        {
            
            serviceUnderTest = new MapperService();
            conversionRequest = new ConversionRequest();
            conversion = new Entities.Conversion
            {
                UserName = "Scott.Thomas",
            };
            conversion.From.Unit = ConversionUnit.Celsius;
            conversion.From.Value = 1;
            conversion.To.Unit = ConversionUnit.Fahrenheit;
        }

        [Test]
        public void WhenToConversionIsCalled_ThenAConversionObjectIsReturned()
        {
            conversionRequest.FromUnit = "Celsius";
            conversionRequest.ToUnit = "Fahrenheit";
            conversionRequest.Value = 1;

            var result = serviceUnderTest.ToConversion("Scott.Thomas", conversionRequest);

            result.Should().BeEquivalentTo(conversion);
            
        }
    }
}

