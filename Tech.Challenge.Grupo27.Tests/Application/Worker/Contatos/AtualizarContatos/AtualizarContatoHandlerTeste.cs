using Moq;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;
using Tech.Challenge.Grupo27.Domain.Shared;
using Tech.Challenge.Grupo27.Tests.Fixtures;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato.Handler_;
using Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato;
using Tech.Challenge.Grupo27.Domain.Infrastructure.MessageBroker;
using Tech.Challenge.Grupo27.Domain.Commands;

namespace Tech.Challenge.Grupo27.Tests.Application.Worker.Contatos.AtualizarContatos
{
    public class AtualizarContatoHandlerTeste
    {
        private readonly Mock<IContatoAtualizadoProducer> _contatoService;
        private readonly Mock<INotificacaoContext> _notificacaoContext;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public AtualizarContatoHandlerTeste()
        {
            _contatoService = new Mock<IContatoAtualizadoProducer>();
            _notificacaoContext = new Mock<INotificacaoContext>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        // <summary>
        /// Atualizar de contato com sucesso.
        /// </summary>
        [Fact]
        public async Task Atualizar_ContatoValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = ContatoFixture.ObterContatoMock(idContato);
            var request = new AtualizarContatoRequest()
            {
                Id = idContato,
                Nome = contato.Nome,
                Email = contato.Email,
                Telefone = new TelefoneRequest()
                {
                    Numero = contato.Telefone != null ? contato.Telefone.Numero : null,
                    Ddd = contato.Telefone != null ? contato.Telefone.Ddd : null
                }
            };

            _contatoService.Setup(c => c.AtualizarContato
            (
                It.IsAny<ContatoAtualizadoCommand>()
            )).Verifiable();

            var handler = new AtualizarContatoHandler(_contatoService.Object, _notificacaoContext.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert

            Assert.True(resultado.Sucesso);
            Assert.NotNull(resultado);
            Assert.NotNull(resultado.Mensagem);
            Assert.True(resultado.Mensagem.Equals("Solicitação de atualização de contato realizado com sucesso"));


            _contatoService.Verify(c => c.AtualizarContato
           (
               It.IsAny<ContatoAtualizadoCommand>()
           )
           , Times.Once());

        }

        // <summary>
        /// Atualizar contato com campos obrigatórios e inválidos.
        /// </summary>
        [Fact]
        public async Task Atualizar_ContatoSemDadosValidosEhObrigatorios_DeveRetornarErros()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var request = new AtualizarContatoRequest()
            {
                Id = idContato,
                Nome = "",
                Email = "joao.com.br",
                Telefone = new TelefoneRequest()
                {
                    Numero = "00",
                    Ddd = "1132-3652"
                }
            };

            _contatoService.Setup(c => c.AtualizarContato
           (
               It.IsAny<ContatoAtualizadoCommand>()
           )).Verifiable();

            var handler = new AtualizarContatoHandler(_contatoService.Object, _notificacaoContext.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert

            Assert.False(resultado.Sucesso);
            Assert.NotNull(resultado.Mensagem);
            Assert.Empty(resultado.Mensagem);
            Assert.Null(resultado.Data);

            _contatoService.Verify(c => c.AtualizarContato
           (
               It.IsAny<ContatoAtualizadoCommand>()
           )
            , Times.Never());

            _unitOfWork.Verify(x => x.SaveChanges(It.IsAny<CancellationToken>()), Times.Never());
            _unitOfWork.Verify(x => x.CommitTransaction(It.IsAny<CancellationToken>()), Times.Never());

        }
    }
}
