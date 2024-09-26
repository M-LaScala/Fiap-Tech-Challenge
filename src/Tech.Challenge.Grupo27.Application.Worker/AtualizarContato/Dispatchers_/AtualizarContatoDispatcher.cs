using Tech.Challenge.Grupo27.Domain.Commands;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared;

namespace Tech.Challenge.Grupo27.Application.Worker.AtualizarContato.Dispatchers_
{
    public class AtualizarContatoDispatcher : IAtualizarContatoDispatcher
    {
        private readonly IContatoService _contatoService;
        private readonly IUnitOfWork _unitOfWork;
        public AtualizarContatoDispatcher
        (
            IContatoService contatoService,
            IUnitOfWork unitOfWork)
        {
            _contatoService = contatoService;
            _unitOfWork = unitOfWork;
        }
        public async Task AtualizarContatoAsync(ContatoAtualizadoCommand request, CancellationToken cancellationToken)
        {
            var contato = new Contato
           (
               request.Nome,
               request.Email,
               new Domain.Shared.ValueObject.Telefone(request.Telefone.Ddd, request.Telefone.Numero),
               request.Id
            );

            await _unitOfWork.BeginTransaction(cancellationToken);

            await _contatoService.Atualizar(contato, cancellationToken);

            await _unitOfWork.SaveChanges(cancellationToken);
            await _unitOfWork.CommitTransaction(cancellationToken);
        }
    }
}
