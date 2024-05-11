using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace AutoSpare.WebAPI.Extensions
{
    static public class ExceptionHandlerExtension
    {
        //public static void ConfigureExceptionHandler<T>(this WebApplication webApplication,ILogger<T>logger)
        //{
            //webApplication.UseExceptionHandler(builder =>
            //{
            //    builder.Run(async context =>
            //    {
            //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //        context.Response.ContentType = MediaTypeNames.Application.Json;
            //        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            //        if(contextFeature != null)
            //        {
            //            logger.LogError(contextFeature.Error.Message);
            //            context.Response.WriteAsJsonAsync((new{ 
            //            StatusCode=context.Response.StatusCode,
            //            Message=contextFeature.Error.Message,
            //            Title = "Error"
            //            }));
            //        }
            //    });
            //});
        //}
    }
}
