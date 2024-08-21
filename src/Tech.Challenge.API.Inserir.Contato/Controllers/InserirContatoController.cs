using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Challenge.API.Inserir.Contato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InserirContatoController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public InserirContatoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Inserir contato.
        /// </summary>
        /// <returns>Contato cadastrado</returns>
        /// <response code="200">Retorna contato cadastrado</response>
        /// <response code="400">Contato Inválido</response>
        [HttpPost]
        [ProducesResponseType(typeof(ContatoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Realiza cadastro de Contatos")]
        public async ValueTask<IActionResult> Inserir([FromBody] ContatoRequest request, CancellationToken cancellationToken)
        {
            return Created("", await _mediator.Send(request, cancellationToken));
        }
    }
}
