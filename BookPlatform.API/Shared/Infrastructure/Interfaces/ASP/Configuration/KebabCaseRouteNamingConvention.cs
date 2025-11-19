using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.RegularExpressions;

namespace BookPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;

public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        if (controller.Selectors.Any(s => s.AttributeRouteModel != null))
        {
            foreach (var selector in controller.Selectors)
            {
                selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
            }
        }

        foreach (var action in controller.Actions)
        {
            foreach (var selector in action.Selectors)
            {
                selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
            }
        }
    }

    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null
            ? new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?.Replace("[controller]", ToKebabCase(name))
            }
            : null;
    }

    private static string ToKebabCase(string text)
    {
        return string.IsNullOrEmpty(text)
            ? text
            : Regex.Replace(text, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", "-$1", RegexOptions.Compiled).Trim().ToLower();
    }
}