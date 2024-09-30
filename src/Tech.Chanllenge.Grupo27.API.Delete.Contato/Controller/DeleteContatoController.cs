using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Tech.Challenge.Grupo27.Application.Contatos.DeletarContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Chanllenge.Grupo27.API.Delete.Contato.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteContatoController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public DeleteContatoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Remover contatos por Id.
        /// </summary>
        /// <response code="200">Retorna contato removido</response>
        /// <response code="400">Contato não encontrado</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(ContatoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<Notificacao>), (int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Apaga um contato da lista.")]
        public async ValueTask<IActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteContatoRequest(id), cancellationToken));
        }
    }
}
