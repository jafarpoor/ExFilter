using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersPro.Models.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;
        public CustomExceptionFilter(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }
        public void OnException(ExceptionContext context)
        {
            var Result = new ViewResult { ViewName = "CustomException" };
            Result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            Result.ViewData.Add("Exception", "خطای پیش بینی نشده");
            context.Result = Result;
        }
    }
}
