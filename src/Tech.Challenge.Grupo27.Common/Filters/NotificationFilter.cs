using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Net;
using System.Text.Json;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Challenge.Grupo27.Common.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotificacaoContext _notificacaoContext;
        private readonly Serilog.ILogger _logger;
        public NotificationFilter(INotificacaoContext notificacaoContext)
        {
            _notificacaoContext = notificacaoContext;
            _logger = Log.ForContext<NotificationFilter>(); 
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificacaoContext.ExisteNotificacoes)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonSerializer.Serialize(_notificacaoContext.Notificacoes);                
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }
    }
}
