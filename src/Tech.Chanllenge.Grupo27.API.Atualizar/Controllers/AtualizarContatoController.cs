using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Tech.Challenge.Grupo27.Application.AtualizarContato;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Chanllenge.Grupo27.API.AtualizarContato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtualizarContatoController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public AtualizarContatoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Atualizar contato.
        /// </summary>
        /// <returns>Contato atualizado</returns>
        /// <response code="200">Retorna contato atualizado</response>
        /// <response code="400">Contato Inválido</response>
        [HttpPut]
        [ProducesResponseType(typeof(Tech.Challenge.Grupo27.Application.AtualizarContato.ContatoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Altera informações do contato.")]
        public async ValueTask<IActionResult> Atualizar([FromBody] AtualizarContatoRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}
