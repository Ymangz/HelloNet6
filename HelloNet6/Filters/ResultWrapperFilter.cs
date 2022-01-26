using HelloNet6.Module;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HelloNet6.Filters;

public class ResultWrapperFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult r)
        {
            if (r.Value is not ResultVoBase<dynamic>)
            {
                context.Result = new JsonResult(ResultVoBase<dynamic>.CreateSucceedResult(r.Value));
            }
        }
        else if (context.Result is EmptyResult)
        {
        }
    }
}