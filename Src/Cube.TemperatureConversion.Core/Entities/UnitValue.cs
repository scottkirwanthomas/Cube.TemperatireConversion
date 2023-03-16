using System;
using System.Text.Json.Serialization;
using Cube.Temperature.Conversion.Core.Enums;

namespace Cube.Temperature.Conversion.Core.Entities
{
    public class UnitValue
    {
        public double Value { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ConversionUnit Unit { get; set; }
    }
}

