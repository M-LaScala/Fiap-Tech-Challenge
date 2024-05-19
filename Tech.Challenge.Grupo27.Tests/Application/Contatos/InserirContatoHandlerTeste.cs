using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;
using Tech.Challenge.Grupo27.Domain.Shared;
using Moq;
using Tech.Challenge.Grupo27.Tests.Fixtures;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Application.Contatos.InserirContato.Handler_;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;

namespace Tech.Challenge.Grupo27.Tests.Application.Contatos
{
    public class InserirContatoHandlerTeste
    {
        private readonly Mock<IContatoService> _contatoService;
        private readonly Mock<INotificacaoContext> _notificacaoContext;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly ContatoFixture _contatoFixture;

        public InserirContatoHandlerTeste()
        {
            _contatoService = new Mock<IContatoService>();
            _notificacaoContext = new Mock<INotificacaoContext>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _contatoFixture = new ContatoFixture();
        }

        // <summary>
        /// Inserir de contato com sucesso.
        /// </summary>
        [Fact]
        public async Task Inserir_ContatoValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = _contatoFixture.ObterContatoMock(idContato);
            var request = new ContatoRequest()
            {
                Nome = contato.Nome,
                Email = contato.Email,
                Telefone = new TelefoneRequest()
                {
                    Numero = contato.Telefone.Numero,
                    Ddd = contato.Telefone.Ddd
                }
            };

            _contatoService.Setup(c => c.Inserir
            (
                It.IsAny<Contato>(),
                It.IsAny<CancellationToken>())
            ).ReturnsAsync(idContato).Verifiable();           

            var handler = new InserirContatoHandler(_contatoService.Object, _notificacaoContext.Object, _unitOfWork.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert

            Assert.True(resultado.Sucesso);
            Assert.True(resultado.Mensagem.Equals("Contato gravado com sucesso"));

            _contatoService.Verify(c => c.Inserir
            (
                It.IsAny<Contato>(),
                It.IsAny<CancellationToken>())
            , Times.Once());       
            
            _unitOfWork.Verify(x=> x.SaveChanges(It.IsAny<CancellationToken>()), Times.Once());
            _unitOfWork.Verify(x => x.CommitTransaction(It.IsAny<CancellationToken>()), Times.Once());

        }

        // <summary>
        /// Inserir contato com campos obrigatórios e inválidos.
        /// </summary>
        [Fact]
        public async Task Inserir_ContatoSemDadosValidosEhObrigatorios_DeveRetornarErros()
        {
            //Arrange
            var idContato = Guid.NewGuid();            
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

            _contatoService.Setup(c => c.Inserir
            (
                It.IsAny<Contato>(),
                It.IsAny<CancellationToken>())
            ).ReturnsAsync(idContato).Verifiable();

            var handler = new InserirContatoHandler(_contatoService.Object, _notificacaoContext.Object, _unitOfWork.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert

            Assert.False(resultado.Sucesso);
            Assert.Empty(resultado.Mensagem);
            Assert.Null(resultado.Data);

            _contatoService.Verify(c => c.Inserir
            (
                It.IsAny<Contato>(),
                It.IsAny<CancellationToken>())
            , Times.Never());

            _unitOfWork.Verify(x => x.SaveChanges(It.IsAny<CancellationToken>()), Times.Never());
            _unitOfWork.Verify(x => x.CommitTransaction(It.IsAny<CancellationToken>()), Times.Never());

        }
    }
}
