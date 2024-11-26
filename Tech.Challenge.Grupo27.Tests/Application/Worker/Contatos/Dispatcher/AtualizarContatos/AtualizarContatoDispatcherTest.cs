using Tech.Challenge.Grupo27.Domain.Shared;
using Tech.Challenge.Grupo27.Tests.Fixtures;
using Tech.Challenge.Grupo27.Domain.Services;
using Moq;
using Tech.Challenge.Grupo27.Domain.Commands;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Application.Worker.AtualizarContato.Dispatchers_;

namespace Tech.Challenge.Grupo27.Tests.Application.Dispatcher
{
    public class AtualizarContatoDispatcherTest
    {

        private readonly Mock<IContatoService> _contatoService;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public AtualizarContatoDispatcherTest()
        {
            _contatoService = new Mock<IContatoService>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        // <summary>
        /// Atualizar de Contato Dispatcher com sucesso.
        /// </summary>
        [Fact]
        public async Task Atualizar_ContatoDispatcher_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = ContatoFixture.ObterContatoMock(idContato);
            var cancellationTokenSource = new CancellationTokenSource();

            _contatoService.Setup(c => c.Atualizar
            (
                It.IsAny<Contato>(),
                It.IsAny<CancellationToken>()
            )).Verifiable();

            _unitOfWork.Setup(x=> x.BeginTransaction(cancellationTokenSource.Token)).Verifiable();

            var dispatchers = new AtualizarContatoDispatcher(_contatoService.Object, _unitOfWork.Object);

           await dispatchers.AtualizarContatoAsync(new ContatoAtualizadoCommand()
            {
                Email = contato.Email,
                Id = contato.Id,
                Nome = contato.Nome,
                Telefone = new TelefoneCommand()
                {
                    Ddd = contato?.Telefone?.Ddd,
                    Estado = contato?.Telefone?.Estado,
                    Numero = contato?.Telefone?.Numero,
                    Regiao = contato?.Telefone?.Regiao,
                }
            }, cancellationToken: cancellationTokenSource.Token);

            //Assert
            _contatoService.Verify(c => c.Atualizar
             (
                 It.IsAny<Contato>(),
                 It.IsAny<CancellationToken>()
             ), Times.Once());
        }

    }
}
