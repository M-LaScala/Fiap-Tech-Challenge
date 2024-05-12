using Serilog;
using System.Net;
using System.Text;

namespace Tech.Challenge.Grupo27.API.Telemetria
{
    internal class TelemetryMiddleware
    {
        private static bool IRequestWitchBody(HttpRequest r) => r.Method == HttpMethod.Post.ToString() || r.Method == HttpMethod.Put.ToString();         
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var request = context.Request;

            if(IRequestWitchBody(request) && (!string.IsNullOrWhiteSpace(request.ContentType) && !request.ContentType.Contains("multipart/form-data")))
            {
                var requestBody = await GetRequestBodyForTelemetry(context);
                Log.Information($"Request Body: {requestBody}");
            }

            var responseBody = await this.GetResponseBodyForTelemetry(context, next);

            if (!string.IsNullOrEmpty(responseBody)) Log.Information($"Response Body: {responseBody}");
        }

        public async Task<string> GetRequestBodyForTelemetry(HttpContext context)
        {
            var request = context.Request;

            if (!request.Body.CanSeek)
            {
                request.EnableBuffering();
            }

            request.Body.Position = 0;
            var sr = new StreamReader(request.Body, Encoding.UTF8);
            var bodyContent = await sr.ReadToEndAsync().ConfigureAwait(false);
            request.Body.Position = 0;

            return bodyContent;
        }

        public async Task<string> GetResponseBodyForTelemetry(HttpContext context, RequestDelegate next)
        {
            Stream originalBody = context.Request.Body;

            try
            {
                using (var stream = new MemoryStream())
                {
                    context.Response.Body = stream;
                    await next(context);
                    if (context.Response.StatusCode == (int)HttpStatusCode.NoContent) return null;

                    stream.Position = 0;
                    var responseBody = new StreamReader(originalBody).ReadToEnd();
                    stream.Position = 0;
                    await stream.CopyToAsync(originalBody);

                    return responseBody;

                }
            }
            finally 
            {
                context.Response.Body = originalBody;
            }    
        }
    }
}
