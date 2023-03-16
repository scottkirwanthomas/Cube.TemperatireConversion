using System;
using Entities = Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Cube.Temperature.Conversion.Core.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Cube.Temperature.Conversion.Core.Services
{
	public class AuditService: IAuditService
	{
        private readonly string filePath;

        public AuditService(IHostEnvironment hostingEnvironment)
		{
            filePath = hostingEnvironment.ContentRootPath;
		}

        public void Audit(Entities.ServiceResponse response)
        {
            // We're only auditing successful conversions
            if (response.Status.Equals(ResponseStatus.Success))
            {
                var conversion = (Entities.Conversion)response.Data;
                string[] message = { $"User: {conversion.UserName} converted from {conversion.From.Value} {conversion.From.Unit} to {conversion.To.Value} {conversion.To.Unit} on {conversion.ConvertedOn.ToString("yyyy-MM-dd hh:mm:ss")}" };
                File.AppendAllLines($"{filePath}\\audit\\conversions.txt", message);
            }

        }
    }
}

