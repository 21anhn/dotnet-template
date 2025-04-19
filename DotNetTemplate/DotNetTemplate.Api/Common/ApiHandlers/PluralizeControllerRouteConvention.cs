using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DotNetTemplate.WebApi.Common.ApiHandlers
{
    public class PluralizeControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerName = controller.ControllerName.ToLower();
            controller.Selectors[0].AttributeRouteModel.Template = $"api/v1/{controllerName}";
        }
    }
}
