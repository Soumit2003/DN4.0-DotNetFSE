using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var errorMessage = $"[{DateTime.Now}] {exception.Message}\n{exception.StackTrace}\n";

            // Write to log file
            File.AppendAllText("Logs/error_log.txt", errorMessage);

            context.Result = new ObjectResult("An unexpected error occurred. Please contact support.")
            {
                StatusCode = 500
            };
        }
    }
}
