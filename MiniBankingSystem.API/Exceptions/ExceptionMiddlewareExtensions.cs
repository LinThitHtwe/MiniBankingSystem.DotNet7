namespace MiniBankingSystem.API.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        //public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        //{
        //    app.UseExceptionHandler(appError =>
        //    {

        //    });
        //}

        public static void CustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<HandleExceptionMiddleware>();
        }
    }
}
