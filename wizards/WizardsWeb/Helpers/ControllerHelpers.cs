using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Wizards.Services.PermissionService;
using Wizards.Services.Validation.Elements;

namespace WizardsWeb.Helpers;

public static class ControllerHelpers
{
    public static void AddModelErrorByException(this ModelStateDictionary modelState, Exception exception)
    {
        if (exception is InvalidModelException)
        {
            var modelException = exception as InvalidModelException;

            foreach (var data in modelException.ModelStatesData)
            {
                modelState.AddModelError(data.Key, data.Value);
            }
        }
    }
}