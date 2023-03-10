using System.Net;
using FastDeliveryAPI.Exceptions;


namespace FastDeliveryAPI.Middleware;

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
        catch (Exception exepp)
        {
            _logger.LogError(ex, $"ERROR {context.Request.Path}");
            await HandleExceptionAsync(context, exepp);
        }
    }

    public Task HandleExceptionAsync(HttpContext context, Exception exepp)
    {
        context.Response.ContentType = "application/json";
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        var errorDetails = new ErrorDetails
        {
            ErrorType = "Failure",
            ErrorMessage = ex.Message
        };

        if(NotFoundException){
            statusCode = HttpStatusCode.NotFound;
                errorDetails.ErrorType = "No found";
        }else if(BadRequestException){
            statusCode = HttpStatusCode.BadRequest;
            errorDetails.ErrorType = "BadRequest";

        }else if(CreditLimitException=creditLimitException){
            statusCode = HttpStatusCode.BadRequest;
            errorDetails.ErrorType = "BadRequest";
        }else if(EmailException){
            statusCode = HttpStatusCode.BadRequest;
            errorDetails.ErrorType = "Error Email";
        }

        

        string response = JsonConvert.SerializeObject(errorDetails);

        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(response);
    }

    public class ErrorDetails
    {
        public string? ErrorType { get; set; }
        public string? ErrorMessage { get; set; }
    }

}