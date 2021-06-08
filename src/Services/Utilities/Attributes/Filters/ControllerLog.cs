using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Utilities.Attributes.Filters
{
    public class ControllerLog : IActionFilter
    {
        private readonly ILogger _Logger;

        public ControllerLog(ILogger<ControllerLog> logger)
        {
            _Logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            LogFunctionCalled(context.RouteData);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            LogFunctionExited(context.RouteData);
        }

        private void LogFunctionCalled(RouteData routeData)
        {
            string controllerName = routeData.Values["controller"].ToString();
            string functionName = routeData.Values["action"].ToString();

            _Logger.LogInformation("Controller {ControllerName}: Function {FunctionName} has been called.", controllerName, functionName);
        }

        private void LogFunctionExited(RouteData routeData)
        {
            string controllerName = routeData.Values["controller"].ToString();
            string functionName = routeData.Values["action"].ToString();

            _Logger.LogDebug("Controller {ControllerName}: Function {FunctionName} has been exited.", controllerName, functionName);
        }
    }
}