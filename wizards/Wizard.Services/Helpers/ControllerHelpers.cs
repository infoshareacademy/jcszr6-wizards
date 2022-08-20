using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Wizards.Services.Validation.Elements;

namespace Wizards.Services.Helpers;

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

    public static int GetId(this ClaimsPrincipal user)
    {
        if (user == null)
        {
            return 0;
        }

        var claim = user.FindFirst(ClaimTypes.NameIdentifier);

        if (claim == null)
        {
            return 0;
        }

        int result;
        Int32.TryParse(claim.Value, out result);

        return result;
    }
}