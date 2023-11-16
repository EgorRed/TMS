using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using TMS_API_Test1.MyException;

namespace TMS_API_Test1.Middleware
{
    public class CustomExeptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExeptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {

                await HandleExceptionMessageAsync(context, exception);
            }
        }

        //private Task HandleExceptionAsync(HttpContext context, Exception exception)
        //{
        //    var code = HttpStatusCode.InternalServerError;
        //    var result = string.Empty;
        //    switch (exception)
        //    {
        //        case NotFoundException:
        //            code = HttpStatusCode.NotFound;
        //            break;
        //    }

        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int)code;

        //    if (result == string.Empty)
        //    {
        //        result = JsonSerializer.Serialize(new { error = exception.Message });
        //    }

        //    return context.Response.WriteAsync(result);
        //}

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            int сode = (int)HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new
            {
                StatusCode = сode,
                ErrorMessage = exception.Message
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = сode;
            return context.Response.WriteAsync(result);
        }
    }
}
