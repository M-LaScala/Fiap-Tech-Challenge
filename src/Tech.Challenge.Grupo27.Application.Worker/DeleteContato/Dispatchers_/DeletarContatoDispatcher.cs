using Tech.Challenge.Grupo27.Domain.Commands;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared;

namespace Tech.Challenge.Grupo27.Application.Worker.DeleteContato.Dispatchers_
{
    public class DeletarContatoDispatcher : IDeletarContatoDispatcher
    {
        private readonly IContatoService _contatoService;
        private readonly IUnitOfWork _unitOfWork;

        public DeletarContatoDispatcher(IContatoService contatoService, IUnitOfWork unitOfWork)
        {
            _contatoService = contatoService;
            _unitOfWork = unitOfWork;
        }

        public async Task DeletarContatoAsync(ContatoDeletadoCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransaction(cancellationToken);

            await _contatoService.Delete(request.Id, cancellationToken);

            await _unitOfWork.SaveChanges(cancellationToken);
            await _unitOfWork.CommitTransaction(cancellationToken);
        }
    }
}
