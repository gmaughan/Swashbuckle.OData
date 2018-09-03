using System.Diagnostics.Contracts;
using System.Web.Http.Controllers;
using Swagger.Net;

namespace Swashbuckle.OData.Descriptions
{
    internal class MapToDefault : IParameterMapper
    {
        public HttpParameterDescriptor Map(Parameter swaggerParameter, int parameterIndex, HttpActionDescriptor actionDescriptor)
        {
            var required = swaggerParameter.required;
            Contract.Assume(required != null);

            return new ODataParameterDescriptor(swaggerParameter.name, swaggerParameter.GetClrType(), !required.Value, null)
            {
                Configuration = actionDescriptor.ControllerDescriptor.Configuration,
                ActionDescriptor = actionDescriptor
            };
        }
    }
}