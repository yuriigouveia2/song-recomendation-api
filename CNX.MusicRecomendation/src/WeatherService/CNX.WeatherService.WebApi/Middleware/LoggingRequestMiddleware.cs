using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CNX.WeatherService.WebApi.Middleware
{
    public class LoggingRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingRequestMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggingRequestMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                if (context.Request != null)
                {
                    var httpClient = HttpClientFactory.Create();
                    var logUrl = $"http://logservice/api/log-service";
                    var request = new HttpRequestMessage(HttpMethod.Post, logUrl);
                    request.Headers.Add("Accept", "application/json");
                    request.Content = new StringContent(context.Request.ToString());

                    await httpClient.SendAsync(request);
                }
            }
        }
    }
}
