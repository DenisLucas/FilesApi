using System;
using System.Linq;
using System.Threading.Tasks;
using File.Core.Response.Error;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace File.Core.Filters
{
    public class ValidationFilters : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var ErrorsInModelState = context.ModelState
                    .Where(x=> x.Value.Errors.Count > 0).ToDictionary(kvp=> kvp.Key, kvp => kvp.Value.Errors.Select(y=> y.ErrorMessage)).ToArray();
                
                var errorResponse = new ErrorResponse();

                foreach (var error in ErrorsInModelState)
                { 
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel
                            {
                                FieldName = error.Key,
                                ErrorMessage = subError   
                            };
                         errorResponse.ErrorMessage.Add(errorModel);
                    }
                   
                }
                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
            
            await next();
        }
    }
}
