using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public Middleware(RequestDelegate next, ILoggerFactory _logFactory)
        {
            
            _next = next;
            _logger = _logFactory.CreateLogger(" A custom Middleware in Asp.Net Core. ");
        }

        // this is a custom logic for asynchronous invoke method. 
        public async Task Invoke(HttpContext httpContext)                         
        {
           // await httpContext.Response.WriteAsync("Hello from Priyanshi's file  ");
            _logger.LogInformation("This middleware is executing........");
            await _next.Invoke(httpContext);                                           // In this step I called the next middleware. 
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
