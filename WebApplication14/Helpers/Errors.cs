using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Helpers
{
    public class Errors
    {
        public static ModelStateDictionary AddErrorsToModelState(IdentityResult identityResult,ModelStateDictionary modelState)
        {
            foreach (var e in identityResult.Errors)
            {
                modelState.AddModelError(e.Code,e.Description);
            }
            return modelState;
        }
        public static ModelStateDictionary AddErrorToModelState(string Code, string Description,ModelStateDictionary modelState)
        {

                modelState.AddModelError(Code, Description);
            
            return modelState;
        }
    }
}
