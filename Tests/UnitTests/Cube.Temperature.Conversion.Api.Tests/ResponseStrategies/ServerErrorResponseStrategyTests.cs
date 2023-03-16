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
	public class ServerErrorResponseStrategyTests
	{
        private IResponseStrategy strategyUnderTest;
        private Entities.ServiceResponse serviceResponse;

        [SetUp]
        public void Setup()
        {
            strategyUnderTest = new ServerErrorResponseStrategy();
            serviceResponse = new Entities.ServiceResponse();
        }

        [Test]
        public void WhenIsMatchIsCalledWithoutAMatchingServiceResponse_ThenFalseIsReturned()
        {
            serviceResponse.Status = ResponseStatus.Success;

            var result = strategyUnderTest.IsMatch(serviceResponse);

            result.Should().BeFalse();
        }

        [Test]
        public void WhenIsMatchIsCalledWithoutAMatchingServiceResponse_ThenTrueIsReturned()
        {
            serviceResponse.Status = ResponseStatus.Exception;
            serviceResponse.Data = new Entities.ServiceException(new Exception("Boo"));

            var result = strategyUnderTest.IsMatch(serviceResponse);

            result.Should().BeTrue();
        }

        [Test]
        public void WhenCreateResponseIsCalledWithAValidServiceResponse_ThenAServerErrorObjectResultIsReturned()
        {
            var serviceException = new Entities.ServiceException(new Exception("Boo"));
            serviceResponse.Status = ResponseStatus.Exception;
            serviceResponse.Data = serviceException;

            var result = strategyUnderTest.CreateResponse(serviceResponse);

            result.Should().BeOfType<ObjectResult>();
            var okResult = (ObjectResult)result;
            okResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }
    }
}

