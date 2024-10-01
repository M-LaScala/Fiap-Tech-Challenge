using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;
using Moq;
using Tech.Challenge.Grupo27.Tests.Fixtures;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Application.API.InserirContato.Handler_;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;
using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Tests.Application.Worker.Contatos.InserirContatos
{
    public class InserirContatoHandlerTeste
    {
        private readonly Mock<IContatoCriadoProducer> _contatoProducer;
        private readonly Mock<INotificacaoContext> _notificacaoContext;

        public InserirContatoHandlerTeste()
        {
            _contatoProducer = new Mock<IContatoCriadoProducer>();
            _notificacaoContext = new Mock<INotificacaoContext>();
        }

        // <summary>
        /// Inserir de contato com sucesso.
        /// </summary>
        [Fact]
        public async Task Inserir_ContatoValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = ContatoFixture.ObterContatoMock(idContato);
            var request = new ContatoRequest()
            {
                Nome = contato.Nome,
                Email = contato.Email,
                Telefone = new TelefoneRequest()
                {
                    Numero = contato.Telefone != null ? contato.Telefone.Numero : null,
                    Ddd = contato.Telefone != null ? contato.Telefone.Ddd : null
                }
            };

            _contatoProducer.Setup(c => c.CriarContato
            (
                It.IsAny<ContatoCriadoCommand>()
            )).Verifiable();

            var handler = new InserirContatoHandler(_contatoProducer.Object, _notificacaoContext.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.True(resultado.Sucesso);
            Assert.NotNull(resultado.Mensagem);
            Assert.True(resultado.Mensagem.Equals("Solicitação de inclusão de contato realizda com sucesso"));

            _contatoProducer.Verify(c => c.CriarContato
            (
                It.IsAny<ContatoCriadoCommand>()
            )
            , Times.Once());
        }

        // <summary>
        /// Inserir contato com campos obrigatórios e inválidos.
        /// </summary>
        [Fact]
        public async Task Inserir_ContatoSemDadosValidosEhObrigatorios_DeveRetornarErros()
        {
            //Arrange            
            var request = new ContatoRequest()
            {
                Nome = "",
                Email = "teste.com.br",
                Telefone = new TelefoneRequest()
                {
                    Numero = "00",
                    Ddd = "1132-3652"
                }
            };

            _contatoProducer.Setup(c => c.CriarContato
            (
                It.IsAny<ContatoCriadoCommand>()
            )
            ).Verifiable();

            var handler = new InserirContatoHandler(_contatoProducer.Object, _notificacaoContext.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert

            Assert.False(resultado.Sucesso);
            Assert.NotNull(resultado.Mensagem);
            Assert.Empty(resultado.Mensagem);
            Assert.Null(resultado.Data);

            _contatoProducer.Verify(c => c.CriarContato
            (
                It.IsAny<ContatoCriadoCommand>()
            )
            , Times.Never());
        }
    }
}
