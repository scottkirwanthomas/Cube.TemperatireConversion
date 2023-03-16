using Cube.Temperature.Conversion.Api.Factories;
using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Api.ResponseStrategies;
using Cube.Temperature.Conversion.Core.ConversionStrategies;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NUnit.Framework;
using Entities = Cube.Temperature.Conversion.Core.Entities;

namespace Cube.Temperature.Conversion.Api.Tests.Factories
{
    public class ResponseFactoryTests
    {
        private IResponseFactory factoryUnderTest;
        private ServiceResponse serviceResponse;
        private List<IResponseStrategy> responseStrategies;

        [SetUp]
        public void Setup()
        {
            responseStrategies = new List<IResponseStrategy>();
            factoryUnderTest = new ResponseFactory(responseStrategies);
            serviceResponse = new ServiceResponse();

        }

        [Test]
        public void WhenCreateResponseIsCalledWithoutMatchingAStrategy_ThenAnExceptionIsThrown()
        {
            Action act = () => factoryUnderTest.CreateResponse(serviceResponse);
            act.Should().Throw<InvalidOperationException>();

        }

        [Test]
        public void WhenCreateResponseIsCalledWithAValidStrategy_ThenAValidResultIsReturned()
        {
            responseStrategies.Add(new OkResponseStrategy());
            serviceResponse.Status = ResponseStatus.Success;
            serviceResponse.Data = new Entities.Conversion();
            var result = factoryUnderTest.CreateResponse(serviceResponse);

            result.Should().BeOfType<OkObjectResult>();
            var okResult = (OkObjectResult)result;

            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);

        }

        [Test]
        public void WhenCreateResponseIsCalledWithAnException_ThenAServerErrorResponseIsReturned()
        {
            responseStrategies.Add(new ServerErrorResponseStrategy());
            var exception = new Exception("boo");

            var result = factoryUnderTest.CreateResponse(exception);

            result.Should().BeOfType<ObjectResult>();
            var errorResult = (ObjectResult)result;

            errorResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            errorResult.Value.Should().Be("Oops something went wrong");
        }

    }
}