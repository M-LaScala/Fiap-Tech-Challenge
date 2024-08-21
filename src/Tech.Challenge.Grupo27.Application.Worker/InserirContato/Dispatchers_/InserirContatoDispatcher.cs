using Tech.Challenge.Grupo27.Application.Worker.Shared;
using Tech.Challenge.Grupo27.Application.Worker.ViewModels;
using Tech.Challenge.Grupo27.Domain.Commands;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;

namespace Tech.Challenge.Grupo27.Application.Worker.InserirContato.Dispatchers
{
    public class InserirContatoDispatcher
    {
        private readonly IContatoService _contatoService;
        private readonly IUnitOfWork _unitOfWork;
        public InserirContatoDispatcher
        (
            IContatoService contatoService,
            IUnitOfWork unitOfWork)
        {
            _contatoService = contatoService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ContatoCriadoCommand request, CancellationToken cancellationToken)
        {

            var contato = new Contato(request.Nome, request.Email, new Domain.Shared.ValueObject.Telefone(request.Telefone?.Ddd, request.Telefone?.Numero));

            await _unitOfWork.BeginTransaction(cancellationToken);

            await _contatoService.Inserir(contato, cancellationToken);

            await _unitOfWork.SaveChanges(cancellationToken);
            await _unitOfWork.CommitTransaction(cancellationToken);
        }
    }
}
