using System;
using System.Text.Json.Serialization;
using Cube.Temperature.Conversion.Core.Interfaces;

namespace Cube.Temperature.Conversion.Core.Entities
{
    public class Conversion : IServiceResponse
    {
        public Conversion()
        {
            From = new UnitValue();
            To = new UnitValue();
        }

        public string UserName { get; init; }
        public DateTime ConvertedOn { get; set; }

        public UnitValue From { get; init; }

        public UnitValue To { get; init; }
    }
}

