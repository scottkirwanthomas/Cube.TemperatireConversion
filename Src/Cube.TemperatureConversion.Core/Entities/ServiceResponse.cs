using System;
using Cube.Temperature.Conversion.Core.Enums;
using Cube.Temperature.Conversion.Core.Interfaces;
using static Cube.Temperature.Conversion.Core.Entities.ServiceResponse;

namespace Cube.Temperature.Conversion.Core.Entities
{
    public class ServiceResponse
    {

        public ServiceResponse()
        {

        }

        public IServiceResponse Data { get; set; }

        public ResponseStatus Status { get; set; }

    }
}

