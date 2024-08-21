using Swashbuckle.AspNetCore.Annotations;

namespace Tech.Challenge.Grupo27.Application.Worker.ViewModels
{
    public class TelefoneRequest
    {
        [SwaggerSchema(Description = "DDD do telefone de contato com dois dígtos.")]
        public string? Ddd { get; set; }
        [SwaggerSchema(Description = "Número do telefone de contato com 8 a 9 dígitos")]
        public string? Numero { get; set; }        
    }
}
