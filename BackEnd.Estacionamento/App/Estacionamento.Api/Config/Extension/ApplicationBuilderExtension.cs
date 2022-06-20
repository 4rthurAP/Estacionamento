using Estacionamento.Api.Config.MiddleWare;

namespace Estacionamento.Api.Config.Extension
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<LogMiddleWare>(Array.Empty<object>());
            return app;
        }
    }
}
