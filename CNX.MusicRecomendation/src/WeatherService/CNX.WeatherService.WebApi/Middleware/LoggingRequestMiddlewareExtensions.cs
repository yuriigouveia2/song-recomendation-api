using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNX.WeatherService.WebApi.Middleware
{
    public static class LoggingRequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingRequest(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingRequestMiddleware>();
        }
    }
}
