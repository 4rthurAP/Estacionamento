using Estacionamento.CrossCutting.ViewModel;
using Estacionamento.Domain.Models.Bussiness;

using System.Text;
using System.Text.Json;

namespace Estacionamento.Api.Config.MiddleWare
{
    public class LogMiddleWare
    {
        private readonly RequestDelegate _next;
        static readonly HttpClient _client = new HttpClient();

        public LogMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var res = await GetData(context);
            var x = JsonSerializer.Deserialize<object>(res);
            Exception exp;
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                exp = e;                
                context.Response.StatusCode = 400;
            }
            finally
            {
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
