using System;
using System.Net;
using System.Text.Json.Nodes;
using Cube.TemperatureConversion.UI.Enums;
using Cube.TemperatureConversion.UI.Interfaces;
using Cube.TemperatureConversion.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Cube.TemperatureConversion.UI.Services
{
	public class ConversionService: IConversionService
    {
        private readonly HttpClient httpClient;
        private readonly ConversionServiceOptions options;

		public ConversionService(HttpClient httpClient
            , IOptions<ConversionServiceOptions> options)
		{
            this.httpClient = httpClient;
            this.options = options.Value;
            httpClient.DefaultRequestHeaders.Add("userName", this.options.UserName);
		}

        public string ConstructConversionUrl(TemperatureUnitConversion request)
        {
            return $"{options.BasePath}?fromunit={request.FromUnit}&tounit={request.ToUnit}&value={request.FromValue}";
        }

        public async Task<ServiceResponse<double>> ConvertAsync(TemperatureUnitConversion request)
        {

            // Construct uri
            var url = ConstructConversionUrl(request);

            
            // call api
            var response = await httpClient.GetAsync(url);

            switch(response.StatusCode)
            {
                case  HttpStatusCode.OK:
                    var conversionResult = JsonObject.Parse(response.Content.ReadAsStringAsync().Result);
                    var result = conversionResult["to"]["value"].GetValue<double>(); 
                    return new ServiceResponse<double> { Status = ResponseStatus.Success, Value = result };

                case HttpStatusCode.BadRequest:
                    return new ServiceResponse<double> { Status = ResponseStatus.ValidationFailure, Message = "Some details were incorrect, please try again" };

                default:
                    return new ServiceResponse<double> { Status = ResponseStatus.Error, Message = "Oops, something went wrong, please try again" };
            }
                       
            
        }
    }
}

