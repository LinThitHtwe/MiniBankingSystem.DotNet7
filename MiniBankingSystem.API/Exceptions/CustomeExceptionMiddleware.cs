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

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            switch (exception)
            {
                case NotFoundException ex:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await httpContext.Response.WriteAsJsonAsync(new ApiResponse()
                    {
                        message = ex.Message,
                        responseData = new object(),
                        statusCode = (int)HttpStatusCode.NotFound,
                        time = DateTime.Now,
                    });
                    break;

                case DBModifyException ex:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
                    await httpContext.Response.WriteAsJsonAsync(new ApiResponse()
                    {
                        message = ex.Message,
                        responseData = new object(),
                        statusCode = (int)HttpStatusCode.InternalServerError,
                        time = DateTime.Now,
                    });
                    break;

                default:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await httpContext.Response.WriteAsJsonAsync(new ApiResponse()
                    {
                        message = "An unexpected error occurred.",
                        responseData = new object(),
                        statusCode = (int)HttpStatusCode.InternalServerError,
                        time = DateTime.Now,
                    });
                    break;
            }
        }

    }
}
