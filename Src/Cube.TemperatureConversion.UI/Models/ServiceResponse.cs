using System;
using System.Text.Json.Serialization;
using Cube.TemperatureConversion.UI.Enums;

namespace Cube.TemperatureConversion.UI.Models
{
    public class ServiceResponse<T>
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ResponseStatus Status { get; set; }

        public T Value { get; set; }

        public string Message { get; set; }
    }
}

