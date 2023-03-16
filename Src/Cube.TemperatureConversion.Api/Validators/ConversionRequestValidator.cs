using System;
using Cube.Temperature.Conversion.Api.Models;
using Cube.Temperature.Conversion.Core.Enums;
using FluentValidation;

namespace Cube.Temperature.Conversion.Api.Validators
{
    public class ConversionRequestValidator : AbstractValidator<ConversionRequest>
    {
        public ConversionRequestValidator()
        {
            RuleFor(x => x.FromUnit).NotNull().IsEnumName(typeof(ConversionUnit), caseSensitive: false);
            RuleFor(x => x.ToUnit).NotNull().IsEnumName(typeof(ConversionUnit), caseSensitive: false);

        }
    }
}

