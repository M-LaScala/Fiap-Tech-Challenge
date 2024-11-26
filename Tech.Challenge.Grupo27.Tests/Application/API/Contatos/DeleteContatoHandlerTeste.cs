using Moq;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Tests.Fixtures;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;
using Tech.Challenge.Grupo27.Domain.Commands;
using Tech.Challenge.Grupo27.Application.DeletarContato;

namespace Tech.Challenge.Grupo27.Tests.Application.Contatos
{
    public class DeleteContatoHandlerTeste
    {
        private readonly Mock<IContatoService> _contatoService;        
        private readonly Mock<IContatoDeletadoProducer> _contatoProducer;        

        public DeleteContatoHandlerTeste()
        {            
            _contatoService = new Mock<IContatoService>();
            _contatoProducer = new Mock<IContatoDeletadoProducer>();
        }

        // <summary>
        /// Delete de contato com sucesso.
        /// </summary>
        [Fact]
        public async Task Delete_ContatoValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = ContatoFixture.ObterContatoMock(idContato);
            var request = new DeleteContatoRequest(idContato);

            _contatoService.Setup(c => c.ObterPorId
            (
                It.Is<Guid?>(x=> x.Equals(idContato))
            )).ReturnsAsync(contato).Verifiable();

            var handler = new DeleteContatoHandler(_contatoService.Object, _contatoProducer.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.True(resultado.Sucesso);
            Assert.NotNull(resultado.Mensagem);
            Assert.True(resultado.Mensagem.Equals("Solicitação de delete realizado com sucesso"));

            _contatoService.Verify(c => c.ObterPorId
            (
                It.Is<Guid?>(x => x.Equals(idContato))
            )
            , Times.Once());
        }

        // <summary>
        /// Delete de contato com id não encontrado.
        /// </summary>
        [Fact]
        public async Task Delete_ContatoIdNaoEncontrado_DeveRetornarNull()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            Contato? contato = null;
            var request = new DeleteContatoRequest(idContato);

            _contatoService.Setup(c => c.ObterPorId
            (
                It.Is<Guid>(x => x.Equals(idContato))
            )).ReturnsAsync(contato).Verifiable();

            var handler = new DeleteContatoHandler(_contatoService.Object, _contatoProducer.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert

            Assert.False(resultado.Sucesso);
            Assert.NotNull(resultado.Mensagem);
            Assert.True(resultado.Mensagem.Equals("Contato não encontrado"));
            Assert.Null(resultado.Data);

            _contatoProducer.Verify(c => c.DeleteContato
            (
                It.Is<ContatoDeletadoCommand>(x => x.Equals(idContato)))
            , Times.Never());
        }
    }
}
