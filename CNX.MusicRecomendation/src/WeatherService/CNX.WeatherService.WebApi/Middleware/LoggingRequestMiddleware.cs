using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                if (context.Request != null)
                {
                    await sendLogRequest(context.Request);
                }
            }
        }

        private async Task sendLogRequest(HttpRequest httpRequest)
        {
            try
            {
                var httpClient = HttpClientFactory.Create();
                var logUrl = $"http://logservice/api/log-service/log";
                var request = new HttpRequestMessage(HttpMethod.Post, logUrl);

                var logContent = new StringBuilder();
                logContent.Append($"{httpRequest.Method} | {httpRequest.Scheme} | {httpRequest.Host}");
                if (httpRequest.ContentLength > 0 && httpRequest.Body != null)
                    logContent.Append($" | {httpRequest.Body}");

                var logJson = new { content = logContent.ToString() };
                request.Content = new StringContent(JsonConvert.SerializeObject(logJson), Encoding.UTF8, "application/json");

                await httpClient.SendAsync(request);
            }
            catch
            {
                return;
            }
        }
    }
}
