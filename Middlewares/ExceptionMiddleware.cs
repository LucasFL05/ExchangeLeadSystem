using System.Net;
using System.Text.Json;

namespace ExchangeLeadSystem.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Resource not found");
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, "Recurso não encontrado.");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Unauthorized access");
                await HandleExceptionAsync(context, HttpStatusCode.Unauthorized, "Acesso não autorizado.");
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid request");
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error");
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,
                    "Ocorreu um erro interno. Tente novamente mais tarde.");
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            HttpStatusCode statusCode,
            string message)
        {
            if (context.Response.HasStarted)
            {
                _logger.LogWarning("Response already started, cannot handle exception.");
                return;
            }

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new ErrorResponse
            {
                Success = false,
                Status = (int)statusCode,
                Message = message,
                TraceId = context.TraceIdentifier
            };

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
    }

    public class ErrorResponse
    {
        public bool Success { get; set; }
        public int Status { get; set; }
        public string? Message { get; set; }
        public string? TraceId { get; set; }
    }
}