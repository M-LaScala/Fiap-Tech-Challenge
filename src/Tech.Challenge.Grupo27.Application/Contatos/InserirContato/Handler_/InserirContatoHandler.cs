using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Shared;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Challenge.Grupo27.Application.Contatos.InserirContato.Handler_
{
    public class InserirContatoHandler : IHandler<ContatoRequest, ContatoResponse>
    {
        private readonly IContatoService _contatoService;
        private readonly INotificacaoContext _notificacaoContext;
        private readonly IUnitOfWork _unitOfWork;
        public InserirContatoHandler
        (
            IContatoService contatoService,
            INotificacaoContext notificacaoContext,
            IUnitOfWork unitOfWork)
        {
            _contatoService = contatoService;
            _notificacaoContext = notificacaoContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContatoResponse>Handle(ContatoRequest request, CancellationToken cancellationToken)
        {
            
            var contato = new Contato(request.Nome,request.Email, new Domain.Shared.ValueObject.Telefone(request?.Telefone?.Ddd,request?.Telefone?.Numero));

            if (contato.Invalid)
            {
                _notificacaoContext.AddNotificacoes(contato?.ValidationResult);
                return new ContatoResponse("", false, null);
            }

            await _unitOfWork.BeginTransaction(cancellationToken);

            var idRegistrado = await _contatoService.Inserir(contato,cancellationToken);

            await _unitOfWork.SaveChanges(cancellationToken);
            await _unitOfWork.CommitTransaction(cancellationToken);

            return new ContatoResponse("Contato gravado com sucesso", true, new { Id = idRegistrado });
        }
    }
}
