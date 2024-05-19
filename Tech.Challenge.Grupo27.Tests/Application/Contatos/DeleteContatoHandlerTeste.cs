using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;
using Tech.Challenge.Grupo27.Domain.Shared;
using Tech.Challenge.Grupo27.Tests.Fixtures;
using Tech.Challenge.Grupo27.Application.Contatos.InserirContato.Handler_;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Application.Contatos.DeletarContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.DeletarContato.Handler_;

namespace Tech.Challenge.Grupo27.Tests.Application.Contatos
{
    public class DeleteContatoHandlerTeste
    {
        private readonly Mock<IContatoService> _contatoService;        
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly ContatoFixture _contatoFixture;

        public DeleteContatoHandlerTeste()
        {
            _contatoFixture = new ContatoFixture();
            _contatoService = new Mock<IContatoService>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        // <summary>
        /// Delete de contato com sucesso.
        /// </summary>
        [Fact]
        public async Task Delete_ContatoValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = _contatoFixture.ObterContatoMock(idContato);
            var request = new DeleteContatoRequest(idContato);

            _contatoService.Setup(c => c.Delete
            (
                It.Is<Guid>(x=> x.Equals(idContato)),
                It.IsAny<CancellationToken>())
            ).ReturnsAsync(contato).Verifiable();

            var handler = new DeleteContatoHandler(_contatoService.Object, _unitOfWork.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert

            Assert.True(resultado.Sucesso);
            Assert.True(resultado.Mensagem.Equals("Contato removido com sucesso"));

            _contatoService.Verify(c => c.Delete
            (
                It.Is<Guid>(x => x.Equals(idContato)),
                It.IsAny<CancellationToken>())
            , Times.Once());

            _unitOfWork.Verify(x => x.SaveChanges(It.IsAny<CancellationToken>()), Times.Once());
            _unitOfWork.Verify(x => x.CommitTransaction(It.IsAny<CancellationToken>()), Times.Once());

        }

        // <summary>
        /// Delete de contato com id não encontrado.
        /// </summary>
        [Fact]
        public async Task Delete_ContatoIdNaoEncontrado_DeveRetornarNull()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            Contato contato = null;
            var request = new DeleteContatoRequest(idContato);

            _contatoService.Setup(c => c.Delete
            (
                It.Is<Guid>(x => x.Equals(idContato)),
                It.IsAny<CancellationToken>())
            ).ReturnsAsync(contato).Verifiable();

            var handler = new DeleteContatoHandler(_contatoService.Object, _unitOfWork.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert

            Assert.False(resultado.Sucesso);
            Assert.Empty(resultado.Mensagem);
            Assert.Null(resultado.Data);

            _contatoService.Verify(c => c.Delete
            (
                It.Is<Guid>(x => x.Equals(idContato)),
                It.IsAny<CancellationToken>())
            , Times.Once());

            _unitOfWork.Verify(x => x.SaveChanges(It.IsAny<CancellationToken>()), Times.Never());
            _unitOfWork.Verify(x => x.CommitTransaction(It.IsAny<CancellationToken>()), Times.Never());

        }
    }
}
