using System;
using Cube.Temperature.Conversion.Core.Entities;

namespace Cube.Temperature.Conversion.Core.Interfaces
{
    public interface IConversionStrategy
    {

        ServiceResponse CreateResponse(Entities.Conversion conversion);


        bool CanConvert(Entities.Conversion conversion);
    }
}

