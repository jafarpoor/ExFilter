using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersPro.Models.Filters
{
    public class ValidModelAttrbute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var Param = context.ActionArguments.SingleOrDefault();
            if (Param.Value == null)
                 context.Result = new BadRequestObjectResult("Model is Null");

            if (!context.ModelState.IsValid)
                  context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}
