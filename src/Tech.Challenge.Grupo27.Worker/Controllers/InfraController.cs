using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Tech.Challenge.Grupo27.Worker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfraController : ControllerBase
    {

        /// <summary>
        /// Obter contato por Id.
        /// </summary>
        /// <returns>Contato</returns>
        /// <response code="200">Retorna Contato cadastrados</response>
        [HttpGet]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [SwaggerOperation(Summary = "Verifica se a API está saudável")]
        public IActionResult Obter() => Ok();
    }
}
