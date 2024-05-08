using Tech.Challenge.Grupo27.Application.Contatos.DeletarContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.Shared;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared;

namespace Tech.Challenge.Grupo27.Application.Contatos.DeletarContato.Handler_
{
    internal class DeleteContatoHandler : IHandler<DeleteContatoRequest, ContatoResponse>
    {
        private readonly IContatoService _contatoService;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteContatoHandler(IContatoService contatoService, IUnitOfWork unitOfWork)
        {
            _contatoService = contatoService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContatoResponse> Handle(DeleteContatoRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransaction(cancellationToken);

            var contato = await _contatoService.Delete(request.Id, cancellationToken);

            await _unitOfWork.SaveChanges(cancellationToken);
            await _unitOfWork.CommitTransaction(cancellationToken);

            if (contato is null)
            {
                return new ContatoResponse("", false, null);
            }

            return new ContatoResponse
            (
                "Contato removido com sucesso",
                true,
                new DeleteContatoResponse
                (
                    contato.Id,
                    contato.Nome,
                    contato.Email,
                    new TelefoneResponse
                    (
                        contato.Telefone.Numero,
                        contato.Telefone.Ddd,
                        contato.Telefone.Estado,
                        contato.Telefone.Regiao
                     )
                  )
            );
        }
    }
}
