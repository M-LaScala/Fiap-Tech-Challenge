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
using Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato.Handler_;
using Tech.Challenge.Grupo27.Application.Contatos.AtualizarContato;

namespace Tech.Challenge.Grupo27.Tests.Application.Contatos
{
    public class AtualizarContatoHandlerTeste
    {
        private readonly Mock<IContatoService> _contatoService;
        private readonly Mock<INotificacaoContext> _notificacaoContext;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly ContatoFixture _contatoFixture;

        public AtualizarContatoHandlerTeste()
        {
            _contatoService = new Mock<IContatoService>();
            _notificacaoContext = new Mock<INotificacaoContext>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _contatoFixture = new ContatoFixture();
        }

        // <summary>
        /// Atualizar de contato com sucesso.
        /// </summary>
        [Fact]
        public async Task Atualizar_ContatoValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = _contatoFixture.ObterContatoMock(idContato);
            var request = new AtualizarContatoRequest()
            {
                Id = idContato,
                Nome = contato.Nome,
                Email = contato.Email,
                Telefone = new TelefoneRequest()
                {
                    Numero = contato.Telefone.Numero,
                    Ddd = contato.Telefone.Ddd
                }
            };

            _contatoService.Setup(c => c.Atualizar
            (
                It.IsAny<Contato>(),
                It.IsAny<CancellationToken>())
            ).Verifiable();

            var handler = new AtualizarContatoHandler(_contatoService.Object, _notificacaoContext.Object, _unitOfWork.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert

            Assert.True(resultado.Sucesso);
            Assert.True(resultado.Mensagem.Equals("Contato atualizado com sucesso"));

            _contatoService.Verify(c=> c.Atualizar
            (
                It.IsAny<Contato>(),
                It.IsAny<CancellationToken>()
            )
            , Times.Once());

            _unitOfWork.Verify(x => x.SaveChanges(It.IsAny<CancellationToken>()), Times.Once());
            _unitOfWork.Verify(x => x.CommitTransaction(It.IsAny<CancellationToken>()), Times.Once());

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
                Email = "teste.com.br",
                Telefone = new TelefoneRequest()
                {
                    Numero = "00",
                    Ddd = "1132-3652"
                }
            };

            _contatoService.Setup(c => c.Atualizar
            (
                It.IsAny<Contato>(),
                It.IsAny<CancellationToken>())
            ).Verifiable();

            var handler = new AtualizarContatoHandler(_contatoService.Object, _notificacaoContext.Object, _unitOfWork.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert

            Assert.False(resultado.Sucesso);
            Assert.Empty(resultado.Mensagem);
            Assert.Null(resultado.Data);

            _contatoService.Verify(c => c.Atualizar
            (
                It.IsAny<Contato>(),
                It.IsAny<CancellationToken>()
            )
            , Times.Never());

            _unitOfWork.Verify(x => x.SaveChanges(It.IsAny<CancellationToken>()), Times.Never());
            _unitOfWork.Verify(x => x.CommitTransaction(It.IsAny<CancellationToken>()), Times.Never());

        }
    }
}
