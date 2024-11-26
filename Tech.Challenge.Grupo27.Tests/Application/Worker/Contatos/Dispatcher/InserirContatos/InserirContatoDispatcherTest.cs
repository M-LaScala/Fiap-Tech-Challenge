using Tech.Challenge.Grupo27.Domain.Shared;
using Tech.Challenge.Grupo27.Tests.Fixtures;
using Tech.Challenge.Grupo27.Domain.Services;
using Moq;
using Tech.Challenge.Grupo27.Application.Worker.DeleteContato.Dispatchers_;
using Tech.Challenge.Grupo27.Application.Worker.AtualizarContato.Dispatchers_;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Application.Worker.InserirContato.Dispatchers;
using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Tests.Application.Dispatcher
{
    public class InserirContatoDispatcherTest
    {

        private readonly Mock<IContatoService> _contatoService;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public InserirContatoDispatcherTest()
        {
            _contatoService = new Mock<IContatoService>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        // <summary>
        /// Inserir de Contato Dispatcher com sucesso.
        /// </summary>
        [Fact]
        public async Task Inserir_ContatoDispatcher_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = ContatoFixture.ObterContatoMock(idContato);
            var cancellationTokenSource = new CancellationTokenSource();

            _contatoService.Setup(c => c.Inserir
            (
                It.IsAny<Contato>(),
                It.IsAny<CancellationToken>()
            )).Verifiable();

            _unitOfWork.Setup(x => x.BeginTransaction(cancellationTokenSource.Token)).Verifiable();

            var dispatchers = new InserirContatoDispatcher(_contatoService.Object, _unitOfWork.Object);
            
            //Act
            await dispatchers.InseirContatoAsync(new ContatoCriadoCommand()
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
            _contatoService.Verify(c => c.Inserir
             (
                 It.IsAny<Contato>(),
                 It.IsAny<CancellationToken>()
             ), Times.Once());
        }

    }
}
