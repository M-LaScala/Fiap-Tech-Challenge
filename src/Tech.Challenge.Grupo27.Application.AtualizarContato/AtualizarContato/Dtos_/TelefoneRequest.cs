using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.Challenge.Grupo27.Application.AtualizarContato
{
    public class TelefoneRequest
    {
        [SwaggerSchema(Description = "DDD do telefone de contato com dois dígtos.")]
        public string? Ddd { get; set; }
        [SwaggerSchema(Description = "Número do telefone de contato com 8 a 9 dígitos")]
        public string? Numero { get; set; }        
    }
}
