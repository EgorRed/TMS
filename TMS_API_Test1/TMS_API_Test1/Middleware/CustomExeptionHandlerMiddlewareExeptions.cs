namespace TMS_API_Test1.Middleware
{
    public static class CustomExeptionHandlerMiddlewareExeptions
    {
        public static IApplicationBuilder UseCustomExeptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExeptionHandlerMiddleware>();
        }
    }
}
