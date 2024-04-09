using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace DemoApi.Api.Extensions
{
    /// <summary>
    /// A set of helper extensions to aid in building an application
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        private static RouteData EmptyRouteData = new RouteData();
        private static ActionDescriptor EmptyActionDescriptor = new ActionDescriptor();

        /// <summary>
        /// Sets up an excaption handler that uses <see cref="GlobalExceptionHandler"/> to fill in the details of a <see cref="ProblemDetails"/> instance
        /// </summary>
        /// <param name="app">The app builder to use to add the middleware</param>
        /// <returns>A <see cref="IApplicationBuilder"/> instance for chaining</returns>
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features?.Get<IExceptionHandlerPathFeature>()?.Error;
                var details = new ProblemDetails { Instance = context.Request.Path };

                var handler = context.RequestServices.GetRequiredService<GlobalExceptionHandler>();
                handler.HandleException(exception, ref details);

                var executor = context.RequestServices.GetRequiredService<IActionResultExecutor<ObjectResult>>();
                var routeData = context.GetRouteData() ?? EmptyRouteData;
                var actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);
                var result = new ObjectResult(details) { StatusCode = (int)HttpStatusCode.BadRequest };

                await executor.ExecuteAsync(actionContext, result);
            }));

            return app;
        }
    }
}
