using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech.Challenge.Grupo27.Domain.Commands
{
    public class ContatoCriadoCommand
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public TelefoneCommand? Telefone { get; set; }
    }
}
