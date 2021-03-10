using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TheMonarchsApi.Middleware
{
    public static class MiddlewareExtenstions
    {
        public static IApplicationBuilder UseHandleExceptionMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<UseHandleExceptionMiddleware>();
        }
    }

    public class UseHandleExceptionMiddleware
    {
        private readonly ILogger<UseHandleExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public UseHandleExceptionMiddleware(RequestDelegate next, ILogger<UseHandleExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = new MediaTypeHeaderValue("application/json").ToString();
                await context.Response.WriteAsync(JsonConvert.SerializeObject(ex.Message), System.Text.Encoding.UTF8);
            }
        }
    }
}
