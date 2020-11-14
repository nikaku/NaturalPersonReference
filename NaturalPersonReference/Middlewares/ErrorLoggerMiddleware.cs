using Microsoft.AspNetCore.Http;
using NLog;
using System;
using System.Threading.Tasks;

namespace NaturalPersonReference.Middlewares
{
    public class ErrorLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger = LogManager.GetLogger("middleloggerrule");

        public ErrorLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                _logger.Log(LogLevel.Error, error.Message);
            }
        }
    }
}
