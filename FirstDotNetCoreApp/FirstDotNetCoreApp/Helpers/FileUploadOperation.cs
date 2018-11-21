using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FirstDotNetCoreApp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FirstDotNetCoreApp.Helpers
{
    public class FileUploadOperation : IOperationFilter
    {

        private readonly IEnumerable<string> _actionsWithUpload = new[]
        {
            //add your upload actions here!
            NamingHelpers.GetOperationId<FilesController>(nameof(FilesController.PostFile))
        };

        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (_actionsWithUpload.Contains(operation.OperationId))
            {
                operation.Parameters.Clear();
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "uploadedFile",
                    In = "formData",
                    Description = "Upload File",
                    Required = true,
                    Type = "file"
                });
                operation.Consumes.Add("multipart/form-data");
            }
        }

        /// <summary>
        /// Refatoring friendly helper to get names of controllers and operation ids
        /// </summary>
        public class NamingHelpers
        {
            public static string GetOperationId<T>(string actionName) where T : ControllerBase => $"{actionName}";

            public static string GetControllerName<T>() where T : ControllerBase => typeof(T).Name.Replace(nameof(ControllerBase), string.Empty);
        }

        //private const string formDataMimeType = "multipart/form-data";

        //public static string[] FormFilePropertyNames { get; } = typeof(IFormFile).GetProperties().Select(p => p.Name).ToArray();

        //public void Apply(Operation operation, OperationFilterContext context)
        //{
        //    var parameters = operation.Parameters;
        //    if (parameters == null || parameters.Count == 0) return;

        //    var formFileParameterNames = new List<string>();
        //    var formFileSubParameterNames = new List<string>();

        //    foreach (var actionParameter in context.ApiDescription.ActionDescriptor.Parameters)
        //    {
        //        var properties =
        //            actionParameter.ParameterType.GetProperties()
        //                .Where(p => p.PropertyType == typeof(IFormFile))
        //                .Select(p => p.Name)
        //                .ToArray();

        //        if (properties.Length != 0)
        //        {
        //            formFileParameterNames.AddRange(properties);
        //            formFileSubParameterNames.AddRange(properties);
        //            continue;
        //        }

        //        if (actionParameter.ParameterType != typeof(IFormFile)) continue;
        //        formFileParameterNames.Add(actionParameter.Name);
        //    }

        //    if (!formFileParameterNames.Any()) return;

        //    var consumes = operation.Consumes;
        //    consumes.Clear();
        //    consumes.Add(formDataMimeType);

        //    foreach (var parameter in parameters.ToArray())
        //    {
        //        if (!(parameter is NonBodyParameter) || parameter.In != "formData") continue;

        //        if (formFileSubParameterNames.Any(p => parameter.Name.StartsWith(p + "."))
        //            || FormFilePropertyNames.Contains(parameter.Name))
        //            parameters.Remove(parameter);
        //    }

        //    foreach (var formFileParameter in formFileParameterNames)
        //    {
        //        parameters.Add(new NonBodyParameter()
        //        {
        //            Name = formFileParameter,
        //            Type = "file",
        //            In = "formData"
        //        });
        //    }
        //}
    }
}
