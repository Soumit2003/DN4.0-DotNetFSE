using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace Experiment3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
     
            var exception = context.Exception;
            var message = $"[{DateTime.Now}] Exception: {exception.Message}\nStackTrace: {exception.StackTrace}\n\n";

            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            File.AppendAllText(Path.Combine(logPath, "exceptions.log"), message);

            context.Result = new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
