using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomModelsApi.Filters
{
    /// <summary>
    /// Custom Exception Filter as per requirements
    /// Catches exceptions occurring in the application and logs them to file
    /// </summary>
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Capture exception details
            var exception = context.Exception;
            var exceptionDetails = $"Exception occurred at {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n" +
                                 $"Message: {exception.Message}\n" +
                                 $"StackTrace: {exception.StackTrace}\n" +
                                 $"Source: {exception.Source}\n" +
                                 $"Request Path: {context.HttpContext.Request.Path}\n" +
                                 $"Request Method: {context.HttpContext.Request.Method}\n" +
                                 new string('-', 80) + "\n";

            try
            {
                // Write exception details to file in system
                var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                var logFile = Path.Combine(logPath, $"exceptions_{DateTime.Now:yyyyMMdd}.log");
                File.AppendAllText(logFile, exceptionDetails);
            }
            catch
            {
                // If logging fails, continue with the response
            }

            // Set the Result property of the exception context to ExceptionResult
            context.Result = new ObjectResult(new
            {
                error = "Internal server error occurred",
                message = exception.Message,
                timestamp = DateTime.Now
            })
            {
                StatusCode = 500
            };

            // Mark exception as handled
            context.ExceptionHandled = true;
        }
    }
}
