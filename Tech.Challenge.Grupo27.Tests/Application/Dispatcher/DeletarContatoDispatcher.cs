﻿using Tech.Challenge.Grupo27.Domain.Shared;
using Tech.Challenge.Grupo27.Tests.Fixtures;
using Tech.Challenge.Grupo27.Domain.Services;
using Moq;

namespace Tech.Challenge.Grupo27.Tests.Application.Dispatcher
{
    public class DeletarContatoDispatcher
    {

        private readonly Mock<IContatoService> _contatoService;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<CancellationToken> _cancellationToken;

        public DeletarContatoDispatcher()
        {
            _contatoService = new Mock<IContatoService>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _cancellationToken = new Mock<CancellationToken>();
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

            await _unitOfWork.BeginTransaction(cancellationToken);

            await _contatoService.Delete(contato.Id, cancellationToken);

            await _unitOfWork.SaveChanges(cancellationToken);
            await _unitOfWork.CommitTransaction(cancellationToken);

            //Assert
            Assert.True(resultado);
            Assert.NotNull(resultado);
            Assert.NotNull(resultado.Mensagem);
            Assert.True(resultado.Mensagem.Equals("Solicitação de atualização de Contato Dispatcher realizado com sucesso"));
        }

    }
}
