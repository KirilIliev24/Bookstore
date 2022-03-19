using Bookstore.Core.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace BookstoreAPI.Services
{
    public static class GlobalErrorExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature is not null)
                    {
                        //Log.Error();
                        await context.Response.WriteAsync(new ErrorModel
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error!!!"
                        }.ToString());
                    }
                }); 
            });
        }
    }
}
