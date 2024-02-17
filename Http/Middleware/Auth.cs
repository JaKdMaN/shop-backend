using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace shop_backend.Http.Middleware
{
    public class Auth
    {
        private readonly RequestDelegate _next;

        public Auth (RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 401)
            {
                object errorResponse;
                var accessToken = context.Request.Headers["Authorization"].FirstOrDefault();

                if (!string.IsNullOrEmpty(accessToken))
                {
                    errorResponse = new { message = "Invalid Token" };
                    context.Response.StatusCode = 419;
                } else
                {
                    errorResponse = new { message = "Вы не авторизованы" };
                }

                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                var jsonResponse = JsonSerializer.Serialize(errorResponse, jsonOptions);

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(jsonResponse);
            }

        }
    }
}
