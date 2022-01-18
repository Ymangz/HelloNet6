using Anotar.Serilog;
using HelloNet6.Module;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HelloNet6.Filters;

public class ExceptionHandlerFilter : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        if (context.ExceptionHandled == false)
        {
            LogTo.Information("{0}",context.Exception.GetType());

            context.Result = new JsonResult(ResultDtoBase<dynamic>.CreateErrorResult(context.Exception.Message));
        }
        context.ExceptionHandled = true; //异常已处理了
        return Task.CompletedTask;
    }
}