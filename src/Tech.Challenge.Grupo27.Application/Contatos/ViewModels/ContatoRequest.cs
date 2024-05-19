using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using Tech.Challenge.Grupo27.Application.Shared;

namespace Tech.Challenge.Grupo27.Application.Contatos.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ContatoRequest : RequestDto, IRequest<ContatoResponse>
    {
        /// <summary>
        /// Nome do contato
        /// </summary>
        [SwaggerSchema(Description = "Nome do contato")]
        public string? Nome { get; set; }
        /// <summary>
        /// Email 
        /// </summary>
        /// 
        [SwaggerSchema(Description = "e-mail de contato.")]
        public string? Email { get; set; }
        /// <summary>
        /// Telefone que possui DDD e Numero
        /// </summary>
        /// 
        public TelefoneRequest Telefone { get; set; }
    }
}
