using System;
using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Api.ResponseStrategies;
using Cube.Temperature.Conversion.Core.ConversionStrategies;
using Entities = Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Cube.Temperature.Conversion.Core.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Cube.Temperature.Conversion.Api.Tests.ResponseStrategies
{
	public class OkResponseStrategyTests
	{
        private IResponseStrategy strategyUnderTest;
        private Entities.ServiceResponse serviceResponse;

        [SetUp]
        public void Setup()
        {
            strategyUnderTest = new OkResponseStrategy();
            serviceResponse = new Entities.ServiceResponse();
        }

        [Test]
        public void WhenIsMatchIsCalledWithoutAMatchingServiceResponse_ThenFalseIsReturned()
        {
            serviceResponse.Status = ResponseStatus.Exception;

            var result = strategyUnderTest.IsMatch(serviceResponse);

            result.Should().BeFalse();
        }

        [Test]
        public void WhenIsMatchIsCalledWithAMatchingServiceResponse_ThenTrueIsReturned()
        {
            serviceResponse.Status = ResponseStatus.Success;
            serviceResponse.Data = new Entities.Conversion();

            var result = strategyUnderTest.IsMatch(serviceResponse);

            result.Should().BeTrue();
        }

        [Test]
        public void WhenCreateResponseIsCalledWithAValidServiceResponse_ThenAnOkObjectResultIsReturned()
        {
            serviceResponse.Status = ResponseStatus.Success;
            serviceResponse.Data = new Entities.Conversion();

            var result = strategyUnderTest.CreateResponse(serviceResponse);

            result.Should().BeOfType<OkObjectResult>();
            var okResult = (OkObjectResult)result;
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(new Entities.Conversion());
        }
    }
}

