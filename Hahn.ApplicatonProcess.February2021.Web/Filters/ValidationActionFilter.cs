using Hahn.ApplicatonProcess.February2021.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Web.Filters
{
    public class ValidationActionFilter: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
           

            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Keys.SelectMany(key => context.ModelState[key].Errors.Select(x => x.ErrorMessage)).ToList();
                var errorResponse = new ErrorResponse
                {
                    Errors = errors
                };

                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }

    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationResultModel(modelState))
        {
            StatusCode = 422;
        }
    }

    public class ValidationResultModel
    {
        public List<string> Errors { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => x.ErrorMessage))
                    .ToList();
        }
    }

}
