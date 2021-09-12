using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Imagegram.Web.Host.Startup
{
    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileUploadMime = "multipart/form-data";
            if (operation.RequestBody == null || !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
                return;

            var fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType == typeof(IFormFileCollection));

            operation.RequestBody.Content[fileUploadMime].Schema.Type = "object";
            operation.RequestBody.Content[fileUploadMime].Schema.Properties =
                                        fileParams.ToDictionary(k => k.Name, v => new OpenApiSchema()
                                        {
                                            Type = "array",
                                            Items = new OpenApiSchema
                                            {
                                                Format = "binary",
                                                Type = "string"
                                            }

                                        });
        }

    }
}