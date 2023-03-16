using System;
using Cube.Temperature.Conversion.Api.Models;
using Cube.Temperature.Conversion.Api.Services;
using Cube.Temperature.Conversion.Api.Validators;
using Cube.Temperature.Conversion.Core.Enums;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace Cube.Temperature.Conversion.Api.Tests.Validators
{
    public class ConversionRequestValidatorTests
    {
        private ConversionRequestValidator validatorUnderTest;
        private ConversionRequest conversionRequest;

        [SetUp]
        public void Setup()
        {
            conversionRequest = new ConversionRequest();
            validatorUnderTest = new ConversionRequestValidator();

        }

        [Test]
        public void WhenFromUnitIsInvalid_ThenAValidationErrorIsCreated()
        {
            conversionRequest.FromUnit = "boo";

            var result = validatorUnderTest.TestValidate(conversionRequest);

            result.ShouldHaveValidationErrorFor(x => x.FromUnit);

        }

        [Test]
        public void WhenFromUnitIsValid_ThenAValidationErrorIsNotCreated()
        {
            conversionRequest.FromUnit = "Celsius";

            var result = validatorUnderTest.TestValidate(conversionRequest);

            result.ShouldNotHaveValidationErrorFor(x => x.FromUnit);

        }

        [Test]
        public void WhenToUnitIsInvalid_ThenAValidationErrorIsCreated()
        {

            conversionRequest.ToUnit = "boo";

            var result = validatorUnderTest.TestValidate(conversionRequest);

            result.ShouldHaveValidationErrorFor(x => x.ToUnit);

        }

        [Test]
        public void WhenToUnitIsValid_ThenAValidationErrorIsNotCreated()
        {

            conversionRequest.ToUnit = "Celsius";

            var result = validatorUnderTest.TestValidate(conversionRequest);

            result.ShouldNotHaveValidationErrorFor(x => x.ToUnit);

        }
    }
}

