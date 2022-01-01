using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

using UdemyNLayerProject.API.DTOs;

namespace UdemyNLayerProject.API.Extentions
{
    //Extention Metod
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            //Startapda kullanılması için extention metodlar kullanırız.
            //env. dedikten sorna okla gösterilen tüm methodlar extention methodlardır.
            app.UseExceptionHandler(config => {

                config.Run(async context => {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();

                    if (error != null)
                    {
                        var exception = error.Error;
                        ErrorDto errorDto = new ErrorDto
                        {
                            Status = 500
                        };
                        errorDto.Errors.Add(exception.Message);
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });
            });
        }
    }
}
