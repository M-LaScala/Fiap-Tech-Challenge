using Microsoft.EntityFrameworkCore;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;
using Tech.Challenge.Grupo27.Infrastructure.EntityFrameworkCore;

namespace Tech.Challenge.Grupo27.Infrastructure.Domain.Models.ContatoAggregate
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly TechChallengeGrupo27Context _context;
        private readonly INotificacaoContext _notificacaoContext;
        public ContatoRepository(TechChallengeGrupo27Context context, INotificacaoContext notificacaoContext)
        {
            _context = context;
            _notificacaoContext = notificacaoContext;
        }

        public async ValueTask Atualizar(Contato contato, CancellationToken cancellationToken)
        {
            var contatoEntity = await _context.Contatos.FirstOrDefaultAsync(c => c.Id == contato.Id);

            if (contatoEntity == null)
            {
                _notificacaoContext.AddNotificacao("CONTATO_NAOEXISTE", "Contato não econtrado");
                return;
            }

            contatoEntity.Nome = contato.Nome;
            contatoEntity.Telefone = contato?.Telefone?.Numero;
            contatoEntity.Ddd = contato?.Telefone?.Ddd;
            contatoEntity.Email = contato?.Email;
            contatoEntity.DataDeAlteracao = DateTime.UtcNow;

            _context.Update(contatoEntity);
        }

        public async ValueTask<Contato?> Delete(Guid? id, CancellationToken cancellationToken)
        {
            var contatoEntity = await _context.Contatos.FirstOrDefaultAsync(c => c.Id == id);

            if (contatoEntity == null)
            {
                _notificacaoContext.AddNotificacao("CONTATO_NAOEXISTE", "Contato não econtrado");
                return default;
            }

            _context.Contatos.Remove(contatoEntity);            
            return MapearContato(contatoEntity);
        }

        public async ValueTask<Guid> Inserir(Contato contato, CancellationToken cancellationToken)
        {
            var contatoEntity = MapearContatpEntity(contato);
            await _context.Contatos.AddAsync(contatoEntity, cancellationToken);
            return contatoEntity.Id;
        }

        public async ValueTask<IEnumerable<Contato>> ObterPorDdd(string? ddd)
        {
            var contatos = new List<Contato>();
            var contatosEntities = await _context.Contatos.Where(c => c.Ddd == ddd).ToListAsync();

            if(contatosEntities?.Count() == 0 || contatosEntities is null) return Enumerable.Empty<Contato>();

            foreach (var contatoEntity in contatosEntities)
            {
                contatos.Add(MapearContato(contatoEntity));
            }

            return contatos;
        }

        public async ValueTask<Contato?> ObterPorId(Guid? id)
        {
           var contatoEntity = await _context.Contatos.FirstOrDefaultAsync(c => c.Id == id);

            if (contatoEntity is null) return default;

            return MapearContato(contatoEntity);
        }

        private static Contato MapearContato(ContatoEntity contatoEntity)
        {
            return new Contato(contatoEntity.Id, contatoEntity.Nome, contatoEntity.Email, new Grupo27.Domain.Shared.ValueObject.Telefone(contatoEntity.Ddd, contatoEntity.Telefone));
        }

        private static ContatoEntity MapearContatpEntity(Contato contato)
        {
            return new ContatoEntity(contato.Nome, contato.Email, contato?.Telefone?.Numero, contato?.Telefone?.Ddd);
        }
    }
}
