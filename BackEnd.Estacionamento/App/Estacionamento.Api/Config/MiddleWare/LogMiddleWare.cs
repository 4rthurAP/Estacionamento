using Estacionamento.CrossCutting.ViewModel;
using Estacionamento.Domain.Models.Bussiness;

using Microsoft.AspNetCore.Http;

using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace Estacionamento.Api.Config.MiddleWare
{
    public class LogMiddleWare
    {
        private readonly RequestDelegate _next;
        private static readonly HttpClient _client = new HttpClient();
        private Exception Exception;
        public LogMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var res = await GetData(context);
            var serializedRequest = JsonSerializer.Deserialize<object>(res);
            var codigo = Guid.NewGuid();
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                Exception = e;
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = $"Ocorreu um erro inesperado! Por favor use o código do erro ({codigo})" },new JsonSerializerOptions { WriteIndented = true}));
            }
            finally
            {
                var x = new
                {
                    Request = serializedRequest,
                    Host = context.Request.Host,
                    Path = context.Request.Path,
                    UserName = context.User.Identity.Name,
                    Exption = Exception.Message ?? null,
                };
                await _client.PostAsJsonAsync("https://localhost:5000/SendToQueue", x);
            }
        }

        private static async Task<string> GetData(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();

            using StreamReader reader = new(httpContext.Request.Body, encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false, bufferSize: 4096, leaveOpen: true);

            string body = await reader.ReadToEndAsync();

            httpContext.Request.Body.Position = 0;

            return body;
        }
    }
}
