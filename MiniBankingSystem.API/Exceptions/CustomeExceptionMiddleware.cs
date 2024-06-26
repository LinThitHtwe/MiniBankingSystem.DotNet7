using MiniBankingSystem.Constants.Exceptions;
using System.Net;

namespace MiniBankingSystem.API.Exceptions
{
    public class CustomeExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomeExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(NotFoundException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception)
            {
                //await HandleExceptionAsync(httpContext);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext,Exception exception)
        {
            if(exception is NotFoundException)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await httpContext.Response.WriteAsJsonAsync(new ApiResponse()
                {
                    message = "NotFound Test Exception CUstom",
                    responseData = { },
                    statusCode = (int)HttpStatusCode.NotFound,
                    time = DateTime.Now,
                });
                return;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new ApiResponse()
            {
                message = "Test Exception CUstom",
                responseData = { },
                statusCode = (int)HttpStatusCode.InternalServerError,
                time = DateTime.Now,
            });
        }
    }
}
