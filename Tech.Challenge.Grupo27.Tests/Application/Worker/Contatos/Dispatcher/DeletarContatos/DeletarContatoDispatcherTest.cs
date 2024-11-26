using Tech.Challenge.Grupo27.Domain.Shared;
using Tech.Challenge.Grupo27.Tests.Fixtures;
using Tech.Challenge.Grupo27.Domain.Services;
using Moq;
using Tech.Challenge.Grupo27.Application.Worker.AtualizarContato.Dispatchers_;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Application.Worker.DeleteContato.Dispatchers_;

namespace Tech.Challenge.Grupo27.Tests.Application.Dispatcher
{
    public class DeletarContatoDispatcherTest
    {

        private readonly Mock<IContatoService> _contatoService;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public DeletarContatoDispatcherTest()
        {
            _contatoService = new Mock<IContatoService>();
            _unitOfWork = new Mock<IUnitOfWork>();      
        }

        // <summary>
        /// Deletar de Contato Dispatcher com sucesso.
        /// </summary>
        [Fact]
        public async Task Deletar_ContatoDispatcher_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = ContatoFixture.ObterContatoMock(idContato);

            var cancellationTokenSource = new CancellationTokenSource();

            _contatoService.Setup(c => c.Delete
            (
                It.IsAny<Guid?>(),
                It.IsAny<CancellationToken>()
            )).Verifiable();

            _unitOfWork.Setup(x => x.BeginTransaction(cancellationTokenSource.Token)).Verifiable();

            var dispatchers = new DeletarContatoDispatcher(_contatoService.Object, _unitOfWork.Object);

            //Act
            await dispatchers.DeletarContatoAsync(new Grupo27.Domain.Commands.ContatoDeletadoCommand() { Id = idContato }, cancellationTokenSource.Token);

            //Assert
            _contatoService.Verify(c => c.Delete
            (
                It.IsAny<Guid?>(),
                It.IsAny<CancellationToken>()
            ), Times.Once());
        }

    }
}
