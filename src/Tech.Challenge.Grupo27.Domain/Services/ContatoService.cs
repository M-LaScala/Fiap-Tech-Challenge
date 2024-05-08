using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Models.RegioesDddAggregate;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Challenge.Grupo27.Domain.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IRegiaoDddRepository _regiaoDddRepository;
        private readonly INotificacaoContext _notificacaoContext;

        public ContatoService
        (
            IContatoRepository contatoRepository,
            IRegiaoDddRepository regiaoDddRepository,
            INotificacaoContext notificacaoContext)
        {
            _contatoRepository = contatoRepository;
            _regiaoDddRepository = regiaoDddRepository;
            _notificacaoContext = notificacaoContext;
        }

        public async ValueTask Aualizar(Contato contato, CancellationToken cancellationToken)
        {
            var regiao = await _regiaoDddRepository.ObterRegiaoPorCodigoDdd(Convert.ToInt32(contato.Telefone.Ddd));

            if (regiao is null)
            {
                _notificacaoContext.AddNotificacao("DDD_INEXISTENTE", "Não foi possível encontrar uma região para o DDD informado");
                return;
            }

            await _contatoRepository.Aualizar(contato, cancellationToken);
        }

        public async ValueTask<Contato> Delete(Guid? id, CancellationToken cancellationToken)
        {
            var contato = await _contatoRepository.Delete(id, cancellationToken);
            
            if (contato is null) return default;
            
            await AdicionarRegiaoDoDdd(contato);
            return contato;
        }

        public async ValueTask<Guid> Inserir(Contato contato, CancellationToken cancellationToken)
        {
            var regiao = await _regiaoDddRepository.ObterRegiaoPorCodigoDdd(Convert.ToInt32(contato.Telefone.Ddd));

            if (regiao is null)
            {
                _notificacaoContext.AddNotificacao("DDD_INEXISTENTE", "Não foi possível encontrar uma região para o DDD informado");
                return Guid.Empty;
            }

            return await _contatoRepository.Inserir(contato, cancellationToken);
        }

        public async ValueTask<IEnumerable<Contato>> ObterPorDdd(string ddd)
        {
            var contatos = await _contatoRepository.ObterPorDdd(ddd);
            RegiaoDdd regiao = await ObterRegiaoPorDDD(ddd);

            foreach (var contato in contatos)
            {
                PreencherRegiaoDddd(contato, regiao);
            }

            return contatos;
        }

        public async ValueTask<Contato> ObterPorId(Guid? id)
        {
            var contato = await _contatoRepository.ObterPorId(id);

            if (contato is null) return default;

            await AdicionarRegiaoDoDdd(contato);
            return contato;
        }

        private async Task AdicionarRegiaoDoDdd(Contato contato)
        {
            var regiao = await ObterRegiaoPorDDD(contato.Telefone.Ddd);
            PreencherRegiaoDddd(contato, regiao);
        }

        private async Task<RegiaoDdd> ObterRegiaoPorDDD(string ddd)
        {
            return await _regiaoDddRepository.ObterRegiaoPorCodigoDdd(Convert.ToInt32(ddd));
        }

        private void PreencherRegiaoDddd(Contato contato, RegiaoDdd regiao)
        {
            if (regiao is not null)
            {
                contato.Telefone.AdicionarRegiaoDoDdd(regiao.Descricao, regiao.Estado);
            }
        }


    }
}
