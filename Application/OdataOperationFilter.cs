using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace lab4.Application
{
    public class ODataOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            var odataParams = new[]
            {
            "$filter", "$orderby", "$expand", "$select", "$top", "$skip", "$count"
            };

            foreach (var param in odataParams)
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = param,
                    In = ParameterLocation.Query,
                    Schema = new OpenApiSchema { Type = "string" },
                    Description = $"OData {param} query option",
                    Required = false
                });
            }
        }
    }

}
