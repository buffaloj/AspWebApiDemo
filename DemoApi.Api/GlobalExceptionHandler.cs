using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using DemoApi.Api.Resources;

namespace DemoApi.Api
{
    /// <summary>
    /// A class used to handle an unhandled exception that bubbles up from an endpoint or other middleware
    /// </summary>
    public class GlobalExceptionHandler
    {
        private readonly ILogger _logger;
        private readonly bool _isDevelopment = false;

        /// <summary>
        /// Constructs an instance of the object
        /// </summary>
        /// <param name="logFactory">A factory used to create a logger instance</param>
        /// <param name="env">The environment the app is running in</param>
        public GlobalExceptionHandler(ILoggerFactory logFactory,
                                      IWebHostEnvironment env)
        {
            _logger = logFactory.CreateLogger<GlobalExceptionHandler>();
            _isDevelopment = env?.IsDevelopment() ?? false;
        }

        /// <summary>
        /// Handles an exception by filling in a <see cref="ProblemDetails"/> instance and logging errors
        /// </summary>
        /// <param name="ex">The exception being handled</param>
        /// <param name="details">A details instance to fill in</param>
        public void HandleException(Exception ex, ref ProblemDetails details)
        {
            details.Detail = ex.Message;

            switch (ex)
            {
                case ValidationException v:
                    _logger?.LogInformation(ex, ex.Message, ex.Data);
                    details.Status = (int)HttpStatusCode.BadRequest;
                    details.Title = ApiResources.ValidationErrorTitle;
                    break;
                default:
                    _logger?.LogError(ex, ex.Message, ex.Data);
                    details.Status = (int)HttpStatusCode.InternalServerError;
                    details.Title = ApiResources.InternalServerErrorTitle;

                    if (!_isDevelopment)
                        details.Detail = ApiResources.InternalServerErrorDesc;

                    break;
            }
        }
    }
}
