using System.Net;
using Newtonsoft.Json;
using NTG.ShipmentManagement.Applicaiton.Exceptions;

namespace NTG.ShipmentManagement.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "applicaiton/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string result = JsonConvert.SerializeObject(new { error = exception.Message });

            switch (exception)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case ValidationException validation:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(new { error = validation.Errors });
                    break;
                case NotFoundException notFound:
                    statusCode = HttpStatusCode.NoContent;
                    break;
                case UnauthorizedAccessException unauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                default:
                    break;
            }

            httpContext.Response.StatusCode = (int)statusCode;
            return httpContext.Response.WriteAsync(result);
        }
    }
}
