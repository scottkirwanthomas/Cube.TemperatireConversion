using Cube.Temperature.Conversion.Api.Factories;
using Cube.Temperature.Conversion.Api.Interfaces;
using Cube.Temperature.Conversion.Api.ResponseStrategies;
using Cube.Temperature.Conversion.Api.Services;
using Cube.Temperature.Conversion.Api.Validators;
using Cube.Temperature.Conversion.Core;
using FluentValidation;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version="v1",
            Title="Unit Conversion API",
            Description= "An ASP.NET Core Web API for converting a value from one unit type to another."
        });
        c.DescribeAllParametersInCamelCase();
        c.EnableAnnotations();
        foreach (var xmlDocFile in Directory.EnumerateFiles(AppContext.BaseDirectory, "*.XML"))
        {
            c.IncludeXmlComments(xmlDocFile);
        }

    }
);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddValidatorsFromAssemblyContaining<ConversionRequestValidator>();
builder.Services.AddScoped<IMapperService, MapperService>();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<IResponseFactory, ResponseFactory>();
builder.Services.AddScoped<IResponseStrategy, OkResponseStrategy>();
builder.Services.AddScoped<IResponseStrategy, ServerErrorResponseStrategy>();
builder.Services.AddScoped<IResponseStrategy, ValidationFailureResponseStrategy>();
builder.Services.ConfigureCore(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

