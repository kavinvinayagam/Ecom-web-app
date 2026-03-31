using Microsoft.AspNetCore.Mvc.Filters;

namespace TestWebAPI.Filters
{
    public class ResultFilter:Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("[ResultFilter]Befor result executes");
            context.HttpContext.Response.Headers.Append("X-Customer-Header", "HelloFromResultFilter");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("[ResultFilter] After result executed");
        }
    }
}
