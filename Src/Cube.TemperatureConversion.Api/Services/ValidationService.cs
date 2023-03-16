using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Api.Models;
using Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using FluentValidation;

namespace Cube.Temperature.Conversion.Api.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IValidator<ConversionRequest> conversionRequestValidator;

        public ValidationService(IValidator<ConversionRequest> conversionRequestValidator)
        {
            this.conversionRequestValidator = conversionRequestValidator;
        }

        public ServiceResponse ValidateConversionRequest(string userName, ConversionRequest conversionRequest)
        {
            var result = conversionRequestValidator.Validate(conversionRequest);
            if (!string.IsNullOrEmpty(userName.Trim()) && result.IsValid)
            {
                return new ServiceResponse { Status = ResponseStatus.Success };
            }
            return new ServiceResponse { Status = ResponseStatus.ValidationFailure };
        }
    }
}

