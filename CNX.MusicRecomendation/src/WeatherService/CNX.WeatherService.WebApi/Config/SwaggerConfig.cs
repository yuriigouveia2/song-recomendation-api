using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNX.WeatherService.WebApi.Config
{
    public static class SwaggerConfig
    {
        private static bool isDocDefined { get; set; } = false;
        private static bool isSecurityDefined { get; set; } = false;

        public static SwaggerGenOptions MapBuilder<TFrom, TTo>(this SwaggerGenOptions _this)
        {
            _this.MapType<TFrom>(() => new OpenApiSchema { Type = typeof(TTo).Name.ToLower() });
            return _this;
        }

        public static SwaggerGenOptions AddSwaggerDoc(this SwaggerGenOptions _this)
        {
            if (isDocDefined)
                return _this;

            isDocDefined = true;
            _this.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Weather API",
                    Version = "v1",
                    Description = "Documentação da API para auxiliar desenvolvedores durante o desenvolvimento das funcionalidades do sistema."
                });
            return _this;
        }

        public static SwaggerGenOptions AddSwaggerSecurity(this SwaggerGenOptions _this)
        {
            if (isSecurityDefined)
                return _this;

            isSecurityDefined = true;

            var security = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                        Scheme = "apiKey",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    }, new List<string>()
                }
            };

            _this.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Primeiro é necessário gerar o 'token' via login no User/Login em seguida insira 'Bearer ' + token no campo Value",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            _this.AddSecurityRequirement(security);

            return _this;
        }


    }
}
