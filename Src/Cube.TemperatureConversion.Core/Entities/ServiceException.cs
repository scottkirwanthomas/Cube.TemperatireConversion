using System;
using Cube.Temperature.Conversion.Core.Interfaces;

namespace Cube.Temperature.Conversion.Core.Entities
{

    public class ServiceException : IServiceResponse
    {
        public ServiceException(Exception exception)
        {
            Exception = exception;
        }

        public Exception @Exception { get; init; }
    }

}

