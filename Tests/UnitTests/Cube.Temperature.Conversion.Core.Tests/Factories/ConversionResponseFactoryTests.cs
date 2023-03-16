using Cube.Temperature.Conversion.Core.Factories;
using Cube.Temperature.Conversion.Core.ConversionStrategies;
using Cube.Temperature.Conversion.Core.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using Cube.Temperature.Conversion.Core.Enums;
using Cube.Temperature.Conversion.Core.Entities;

namespace Cube.Temperature.Conversion.Core.Tests.Factories
{
    public class ConversionResponseFactoryTests
    {
        private IConversionResponseFactory factoryUnderTest;
        private List<IConversionStrategy> conversionStrategies;
        private Entities.Conversion conversion;

        [SetUp]
        public void Setup()
        {
            conversionStrategies = new List<IConversionStrategy>();
            factoryUnderTest = new ConversionResponseFactory(conversionStrategies);
            conversion = new Entities.Conversion { UserName = "Scott.Thomas" };
        }

        [Test]
        public void WhenCreateResponseIsCalledWithoutMatchingAStrategy_ThenAnExceptionIsThrown()
        {
            Action act = () => factoryUnderTest.CreateResponse(conversion);
            act.Should().Throw<InvalidOperationException>();

        }

        [Test]
        public void WhenCreateResponseIsCalledWithAMatchingStrategy_ThenAValidServiceResponseIsReturned()
        {
            conversionStrategies.Add(new NoConversionStrategy());
            conversion.From.Unit = ConversionUnit.Celsius;
            conversion.To.Unit = ConversionUnit.Celsius;

            var result = factoryUnderTest.CreateResponse(conversion);

            result.Should().BeOfType<ServiceResponse>();
            result.Status.Should().Be(ResponseStatus.Success);
            result.Data.Should().BeOfType<Entities.Conversion>();
        }

        [Test]
        public void WhenCreateResponseIsCalledWithAnException_ThenAValidServiceResponseIsReturned()
        {
            var exception = new Exception("boo");

            var result = factoryUnderTest.CreateResponse(exception);

            result.Should().BeOfType<ServiceResponse>();
            result.Status.Should().Be(ResponseStatus.Exception);
            result.Data.Should().BeOfType<ServiceException>();

            var serviceException = (ServiceException)result.Data;
            serviceException.Exception.Should().Be(exception);
        }
    }
}

