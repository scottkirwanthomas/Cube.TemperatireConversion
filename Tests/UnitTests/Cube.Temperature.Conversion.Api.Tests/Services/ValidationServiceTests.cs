using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Api.Models;
using Cube.Temperature.Conversion.Api.Services;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;

namespace Cube.Temperature.Conversion.Api.Tests.Services
{
    public class ValidationServiceTests
    {
        private Mock<IValidator<ConversionRequest>> conversionRequestValidator;
        private IValidationService serviceUnderTest;
        private ConversionRequest conversionRequest;

        [SetUp]
        public void Setup()
        {
            conversionRequestValidator = new Mock<IValidator<ConversionRequest>>();
            serviceUnderTest = new ValidationService(conversionRequestValidator.Object);
            conversionRequest = new ConversionRequest();
        }

        [Test]
        public void WhenValidateConversionRequestIsCalledWithAnEmptyUserName_ThenAValidationFailureResponseIsReturned()
        {
            var result = serviceUnderTest.ValidateConversionRequest(string.Empty, conversionRequest);

            result.Should().BeOfType<ServiceResponse>();
            result.Status.Should().Be(ResponseStatus.ValidationFailure);
        }

        [Test]
        public void WhenValidateConversionRequestIsCalledWithAValidUserNameAndAnInvalidConversionRequest_ThenAValidationFailureResponseIsReturned()
        {
            var result = serviceUnderTest.ValidateConversionRequest(string.Empty, conversionRequest);

            result.Should().BeOfType<ServiceResponse>();
            result.Status.Should().Be(ResponseStatus.ValidationFailure);
        }

        [Test]
        public void WhenValidateConversionRequestIsCalledWithAValidUserNameAndAValidConversionRequest_ThenASuccessResponseIsReturned()
        {
            conversionRequest.FromUnit = "Celsius";
            conversionRequest.ToUnit = "Celsius";
            conversionRequest.Value = 1;

            conversionRequestValidator.Setup(x => x.Validate(It.IsAny<ConversionRequest>())).Returns(new ValidationResult());

            var result = serviceUnderTest.ValidateConversionRequest("Scott.Thomas", conversionRequest);

            result.Should().BeOfType<ServiceResponse>();
            result.Status.Should().Be(ResponseStatus.Success);
        }
    }
}

