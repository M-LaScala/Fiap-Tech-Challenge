
using Serilog;
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
        private readonly ILogger _logger;

        public ContatoService
        (
            IContatoRepository contatoRepository,
            IRegiaoDddRepository regiaoDddRepository,
            INotificacaoContext notificacaoContext)
        {
            _contatoRepository = contatoRepository;
            _regiaoDddRepository = regiaoDddRepository;
            _notificacaoContext = notificacaoContext;
            _logger = Log.ForContext<ContatoService>(); 
        }

        public async ValueTask Atualizar(Contato contato, CancellationToken cancellationToken)
        {
            var regiao = await _regiaoDddRepository.ObterRegiaoPorCodigoDdd(Convert.ToInt32(contato.Telefone.Ddd));

            if (regiao is null)
            {
                var mensagem = $"Não foi possível encontrar uma região para o DDD {contato.Telefone.Ddd}";
                var messageTemplate = $"ContatoService | Atualizar | Mensagem:  {mensagem}";
                _logger.Warning(messageTemplate);                
                _notificacaoContext.AddNotificacao("DDD_INEXISTENTE", mensagem);
                return;
            }

            await _contatoRepository.Atualizar(contato, cancellationToken);
        }

        public async ValueTask<Contato?> Delete(Guid? id, CancellationToken cancellationToken)
        {
            var contato = await _contatoRepository.Delete(id, cancellationToken);

            if (contato is null) return default;

            var regiao = await ObterRegiaoPorDDD(contato.Telefone.Ddd);

            contato.AssociarDddContaARegiao(regiao?.Descricao, regiao?.Estado);

            return contato;
        }

        public async ValueTask<Guid> Inserir(Contato? contato, CancellationToken cancellationToken)
        {

            if (contato is null)
            {
                var mensagem = "O contato deve ser preenchido corretamente";
                var messageTemplate = $"ContatoService | Inserir | Mensagem:  {mensagem}";
                _logger.Warning(messageTemplate);
                _notificacaoContext.AddNotificacao("CONTATO_NULLO",mensagem);
                return Guid.Empty;
            }

            var regiao = await _regiaoDddRepository.ObterRegiaoPorCodigoDdd(Convert.ToInt32(contato.Telefone?.Ddd));

            if (regiao is null)
            {
                var mensagem = $"Não foi possível encontrar uma região para o DDD {contato.Telefone.Ddd}";
                var messageTemplate = $"ContatoService | Inserir | Mensagem:  {mensagem}";
                _logger.Warning(messageTemplate);
                _notificacaoContext.AddNotificacao("DDD_INEXISTENTE", mensagem);
                return Guid.Empty;
            }

            return await _contatoRepository.Inserir(contato, cancellationToken);
        }

        public async ValueTask<IEnumerable<Contato>> ObterPorDdd(string? ddd)
        {
            var contatos = await _contatoRepository.ObterPorDdd(ddd);
            var regiao = await ObterRegiaoPorDDD(ddd);

            foreach (var contato in contatos)
            {
                contato.AssociarDddContaARegiao(regiao?.Descricao, regiao?.Estado);
            }

            return contatos;
        }

        public async ValueTask<Contato?> ObterPorId(Guid? id)
        {
            var contato = await _contatoRepository.ObterPorId(id);

            if (contato is null) return default;

            var regiao = await ObterRegiaoPorDDD(contato?.Telefone?.Ddd);            

            contato.AssociarDddContaARegiao(regiao?.Descricao, regiao?.Estado);

            return contato;
        }

        private async Task<RegiaoDdd?> ObterRegiaoPorDDD(string? ddd)
        {
            if (string.IsNullOrWhiteSpace(ddd)) return default;

            return await _regiaoDddRepository.ObterRegiaoPorCodigoDdd(Convert.ToInt32(ddd));
           
        }         
    }
}
