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
    public class CachReSourceFilter : Attribute, IResourceFilter
    {
        private static readonly Dictionary<string, object> _cache = new
            Dictionary<string, object>();
        private string _cacheKey;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CachReSourceFilter(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _cacheKey = context.HttpContext.Request.Path.ToString();

            if (_cache.ContainsKey(_cacheKey))
            {

                var cachedData = _cache[_cacheKey] as string;
                if (cachedData != null)
                {
                    context.Result = new ViewResult()
                    {
                        ViewName = "Index",
                        ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState)
                        {
                            Model = cachedData,
                        },
                    };

                }
            }
        }


        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (!String.IsNullOrEmpty(_cacheKey) && !_cache.ContainsKey(_cacheKey))
            {
                var result = context.Result as ViewResult;
                if (result != null)
                {
                    _cache.Add(_cacheKey, result.Model);
                }
            }
        }

    }
}
