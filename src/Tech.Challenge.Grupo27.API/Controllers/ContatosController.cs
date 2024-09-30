using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;
using Swashbuckle.AspNetCore.Annotations;

namespace Tech.Challenge.Grupo27.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public ContatosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obter contato por Id.
        /// </summary>
        /// <returns>Contato</returns>
        /// <response code="200">Retorna Contato cadastrados</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ContatoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Busca um contato específico pelo seu Id.")]
        public async ValueTask<IActionResult> ObterPorId(Guid? id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new ObterPorIdRequest(id), cancellationToken));
        }

        /// <summary>
        /// Lista contatos por DDD.
        /// </summary>
        /// <returns>Lista de Contatos</returns>
        /// <response code="200">Retorna Lista de Contatos cadastrados</response>
        [HttpGet]
        [Route("{ddd}/contatos")]
        [ProducesResponseType(typeof(ContatoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Realiza uma busca de contatos filtrados pelo DDD do número de telefone.")]
        public async ValueTask<IActionResult> ObterPorDdd(int? ddd, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new ObterPorDddRequest(ddd), cancellationToken));
        }
    }
}
