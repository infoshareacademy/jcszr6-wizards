using Microsoft.AspNetCore.Mvc;

namespace WizardsWeb.Extensions;
{
    public class MyExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MyExceptionHandler(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<MyExceptionHandler>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }

        private void HandleException(HttpContext context, Exception ex)
        {
            _logger.LogError($"Problem with {context.Request}. Error: {ex.Message}. StackTrace: {ex.StackTrace}");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.Redirect("/Home/Error500");
        }
    }
}
