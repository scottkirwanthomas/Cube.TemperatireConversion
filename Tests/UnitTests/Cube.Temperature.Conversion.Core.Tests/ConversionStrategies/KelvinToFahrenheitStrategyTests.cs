using System;
using Cube.Temperature.Conversion.Core.ConversionStrategies;
using Cube.Temperature.Conversion.Core.Interfaces;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace Cube.Temperature.Conversion.Core.Tests.ConversionStrategies
{
	public class KelvinToFahrenheitStrategyTests
    {
        private IConversionStrategy strategyUnderTest;
        private Entities.Conversion conversion;

        [SetUp]
        public void Setup()
        {
            strategyUnderTest = new KelvinToFarenheitStrategy();
            conversion = new Entities.Conversion { UserName = "Scott.Thomas" };
        }

        [Test]
        public void WhenCanConvertIsCalledWithoutAMatchingConversion_ThenFalseIsReturned()
        {
            conversion.From.Unit = ConversionUnit.Celsius;
            conversion.To.Unit = ConversionUnit.Celsius;

            var result = strategyUnderTest.CanConvert(conversion);

            result.Should().BeFalse();
        }

        [Test]
        public void WhenCanConvertIsCalledWithAMatchingConversion_ThenTrueIsReturned()
        {
            conversion.From.Unit = ConversionUnit.Kelvin;
            conversion.To.Unit = ConversionUnit.Fahrenheit;

            var result = strategyUnderTest.CanConvert(conversion);

            result.Should().BeTrue();
        }

        [Test]
        public void WhenCreateResponseIsCalledWithAValidConversion_ThenAServiceResponseWithACorrectConversionIsCreated()
        {
            var whenConverted = DateTime.Now;
            var convertedValue = -457.86999999999995;

            conversion.From.Unit = ConversionUnit.Celsius;
            conversion.From.Value = 1;
            conversion.To.Unit = ConversionUnit.Fahrenheit;
            
            var result = strategyUnderTest.CreateResponse(conversion);

            result.Should().BeOfType<ServiceResponse>();
            result.Status.Should().Be(ResponseStatus.Success);
            result.Data.Should().BeOfType<Entities.Conversion>();

            var resultingConversion = (Entities.Conversion)result.Data;
            resultingConversion.ConvertedOn.Should().BeAfter(whenConverted);
            resultingConversion.To.Value.Should().Be(convertedValue);
        }
    }
}

