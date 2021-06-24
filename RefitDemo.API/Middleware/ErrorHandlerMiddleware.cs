using Microsoft.AspNetCore.Http;
using RefitDemo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RefitDemo.API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
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
                Console.WriteLine(error.Message);
                Console.Error.WriteLine(error.StackTrace);

                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    _ when error is AppException => (int)HttpStatusCode.BadRequest,
                    _ when error is KeyNotFoundException => (int)HttpStatusCode.NotFound,                    
                    _ => (int)HttpStatusCode.InternalServerError
                };

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                Console.WriteLine($"Response to client: {result}");
                await response.WriteAsync(result);
            }
        }
    }
}
