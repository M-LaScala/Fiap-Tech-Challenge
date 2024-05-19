using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato;
using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.DeletarContato.Dtos;
using System.Net;
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
        /// Inserir contato.
        /// </summary>
        /// <returns>Contato cadastrado</returns>
        /// <response code="200">Retorna contato cadastrado</response>
        /// <response code="400">Contato Inválido</response>
        [HttpPost]
        [ProducesResponseType(typeof(ContatoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Realiza cadastro de Contatos")]
        public async ValueTask<IActionResult> Inserir([FromBody] ContatoRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Atualizar contato.
        /// </summary>
        /// <returns>Contato atualizado</returns>
        /// <response code="200">Retorna contato atualizado</response>
        /// <response code="400">Contato Inválido</response>
        [HttpPut]
        [ProducesResponseType(typeof(ContatoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Altera informações do contato.")]
        public async ValueTask<IActionResult> Atualizar([FromBody] AtualizarContatoRequest request)
        {
            return Ok(await _mediator.Send(request));
        }


        /// <summary>
        /// Obter contato por Id.
        /// </summary>
        /// <returns>Contato</returns>
        /// <response code="200">Retorna Contato cadastrados</response>
        [HttpGet]
        [Route("{id}/contato")]
        [ProducesResponseType(typeof(ContatoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Busca um contato específico pelo seu Id.")]
        public async ValueTask<IActionResult> ObterPorId(Guid? id)
        {
            return Ok(await _mediator.Send(new ObterPorIdRequest(id)));
        }

        /// <summary>
        /// Lista contatos por DDD.
        /// </summary>
        /// <returns>Lista de Contatos</returns>
        /// <response code="200">Retorna Lista de Contatos cadastrados</response>
        [HttpGet]
        [Route("{ddd}/contatos")]
        [ProducesResponseType(typeof(ContatoResponse),(int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Realiza uma busca de contatos filtrados pelo DDD do número de telefone.")]
        public async ValueTask<IActionResult> ObterPorDdd(int? ddd)
        {
            return Ok(await _mediator.Send(new ObterPorDddRequest(ddd)));
        }

        /// <summary>
        /// Remover contatos por Id.
        /// </summary>
        /// <response code="200">Retorna contato removido</response>
        /// <response code="400">Contato não encontrado</response>
        [HttpDelete]
        [Route("{id}/contato")]
        [ProducesResponseType(typeof(ContatoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Apaga um contato da lista.")]
        public async ValueTask<IActionResult> Delete(Guid? id)
        {
            return Ok(await _mediator.Send(new DeleteContatoRequest(id)));
        }

    }
}
