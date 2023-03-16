using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using System;
using Cube.Temperature.Conversion.Core.Interfaces;
using Cube.Temperature.Conversion.Core.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Cube.Temperature.Conversion.Core.Tests.Services
{
    public class ConversionServiceTests
    {
        private Mock<IConversionResponseFactory> conversionResponseFactory;
        private Mock<IAuditService> auditService;
        private IConversionService serviceUnderTest;
        private Entities.Conversion conversion;

        [SetUp]
        public void Setup()
        {
            conversionResponseFactory = new Mock<IConversionResponseFactory>();
            auditService = new Mock<IAuditService>();
            serviceUnderTest = new ConversionService(conversionResponseFactory.Object, auditService.Object);
            conversion = new Entities.Conversion();
        }

        [Test]
        public void WhenConvertIsCalledWithAValidConversion_AndAnexceptionIsThrown_ThenAserviceResponseWithAnExceptionIsReturned()
        {
            var serviceResponse = new ServiceResponse
            {
                Data = new ServiceException(new InvalidOperationException()),
                Status = ResponseStatus.Exception
            };
            conversionResponseFactory.Setup(x => x.CreateResponse(It.IsAny<Entities.Conversion>())).Throws(new InvalidOperationException());
            conversionResponseFactory.Setup(x => x.CreateResponse(It.IsAny<Exception>())).Returns(serviceResponse);
            auditService.Setup(x => x.Audit(It.IsAny<ServiceResponse>())).Verifiable();
            var result = serviceUnderTest.Convert(conversion);

            result.Should().BeOfType<ServiceResponse>();
            result.Status.Should().Be(ResponseStatus.Exception);
            result.Data.Should().BeOfType<ServiceException>();

            var serviceException = (ServiceException)result.Data;
            serviceException.Exception.Should().BeOfType<InvalidOperationException>();
            conversionResponseFactory.VerifyAll();
            auditService.Verify(x => x.Audit(It.IsAny<ServiceResponse>()), Times.Never);
        }

        [Test]
        public void WhenConvertIsCalledWithAValidConversion_AndASuccessfulConversionOccurs_ThenASuccessfulServiceResponseIsReturned()
        {
            var serviceResponse = new ServiceResponse
            {
                Data = conversion,
                Status = ResponseStatus.Success
            };
            conversionResponseFactory.Setup(x => x.CreateResponse(It.IsAny<Entities.Conversion>())).Returns(serviceResponse);
            auditService.Setup(x => x.Audit(It.IsAny<ServiceResponse>())).Verifiable();
            var result = serviceUnderTest.Convert(conversion);

            result.Should().BeOfType<ServiceResponse>();
            result.Status.Should().Be(ResponseStatus.Success);
            result.Data.Should().BeOfType<Entities.Conversion>();
            auditService.Verify(x => x.Audit(It.IsAny<ServiceResponse>()), Times.Once);

        }
    }
}

