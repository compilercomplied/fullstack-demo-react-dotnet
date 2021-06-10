using domain.extensions;
using domain.extensions.Application;
using domain.extensions.Core.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace application.builder.Middleware
{

  public class ExceptionMiddleware
  {

    #region DI
    readonly ILogger<ExceptionMiddleware> _logger;
    readonly RequestDelegate _next;

    public ExceptionMiddleware(
      ILogger<ExceptionMiddleware> logger, 
      RequestDelegate next
    )
    {
      _logger = logger;
      _next = next;
    }
    #endregion DI

    public async Task Invoke(HttpContext context)
    {

      try { await _next(context); }
      catch (Exception ex) { await HandleException(context, ex); }

    }

    Task HandleException(HttpContext context, Exception ex)
    {
      HttpStatusCode code = HttpStatusCode.InternalServerError;

      bool isCustomEx = (ex is OperationException);


      string message = ApplicationMessages.API_DefaultError;
      if (isCustomEx)
      {
        _logger.LogInformation("Error result unwrapped", ex);
        message = ex.Message;
      }
      else
      { 
        _logger.LogCritical("Unhandled exception", ex);
      }


      var httpResponse = new ErrorResponse { Message = message };

      string result = JsonSerializer.Serialize(httpResponse);

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)code;


      return context.Response.WriteAsync(result);

    }

  }

}
