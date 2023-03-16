using System;
using Entities = Cube.Temperature.Conversion.Core.Entities;
using Cube.Temperature.Conversion.Core.Enums;
using Cube.Temperature.Conversion.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Cube.Temperature.Conversion.Core.Services
{
	public class ConversionService: IConversionService
	{
        private readonly IConversionResponseFactory conversionResponseFactory;
        private readonly IAuditService auditService;

		public ConversionService(IConversionResponseFactory conversionResponseFactory
            , IAuditService auditService)
		{
            this.conversionResponseFactory = conversionResponseFactory;
            this.auditService = auditService;
        }

        public Entities.ServiceResponse Convert(Entities.Conversion conversionToRun)
        {
            try
            {
                var response = conversionResponseFactory.CreateResponse(conversionToRun);
                auditService.Audit(response);
                return response;
            }
            catch (Exception ex)
            {
                return conversionResponseFactory.CreateResponse(ex);
            }
        }
    }
}

