using System;
using Cube.TemperatureConversion.UI.Interfaces;

namespace Cube.TemperatureConversion.UI.Models
{
    public class TemperatureUnitConversion
    {

        public string FromUnit { get; set; }

        public string ToUnit { get; set; }

        public double FromValue { get; set; }

        public double Result { get; set; }
    }
}

