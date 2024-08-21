using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;
using System.Text.Json;
using Tech.Challenge.Grupo27.Domain.Shared.Exceptions;

namespace Tech.Challenge.Grupo27.Common.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            const string codigoErro = "ERRO_INTERNO_SERVIDOR";
            const string mensagemGenerica = "Ops, erro interno do servidor";

            Log.Error(ex, "{MensagemGenerica} | {ExceptionMessage}", mensagemGenerica, ex.Message);

            var erros = new List<ErroMensagem>()
            {
                new ErroMensagem(codigoErro, mensagemGenerica)
            };

            return HandleResponseMessageAsync(context, erros, HttpStatusCode.InternalServerError);
        }

        private static Task HandleResponseMessageAsync(HttpContext context, IEnumerable<ErroMensagem> erros, HttpStatusCode httpStatusCode)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            var resposta = JsonSerializer.Serialize(erros.ToList(), options);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;
            return context.Response.WriteAsync(resposta);
        }
    }

    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }

    public static class JsonSerializerOptionsProvider
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            // Configure suas opções aqui, por exemplo:
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
}
