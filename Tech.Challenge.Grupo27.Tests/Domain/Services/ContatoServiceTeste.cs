using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Models.RegioesDddAggregate;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared.Notificacoes;
using Tech.Challenge.Grupo27.Tests.Fixtures;

namespace Tech.Challenge.Grupo27.Tests.Domain.Services
{
    public class ContatoServiceTeste
    {
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly Mock<IRegiaoDddRepository> _regiaoDddRepository;
        private readonly Mock<INotificacaoContext> _notificacaoContext;
        private readonly ContatoFixture _contatoFixture;
        private readonly RegiaoDddFixture _regiaoDddFixture;
        public ContatoServiceTeste()
        {
            _contatoRepository = new Mock<IContatoRepository>();
            _regiaoDddRepository = new Mock<IRegiaoDddRepository>();
            _notificacaoContext = new Mock<INotificacaoContext>();
            _contatoFixture = new ContatoFixture();
            _regiaoDddFixture = new RegiaoDddFixture();
        }

        // <summary>
        /// Criação de contato padrão.
        /// </summary>
        [Fact]
        public async Task Inserir_ContatoValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = _contatoFixture.ObterContatoMock(idContato);

            _contatoRepository.Setup(c=> c.Inserir
            (
                It.Is<Contato>(b=> b.Equals(contato)),
                It.IsAny<CancellationToken>())
            ).ReturnsAsync(idContato).Verifiable();

            _regiaoDddRepository.Setup(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(contato.Telefone.Ddd)))).ReturnsAsync(_regiaoDddFixture.ObterRegiaoDddMock());

            var services  = new ContatoService(_contatoRepository.Object,_regiaoDddRepository.Object, _notificacaoContext.Object);

            //Act
            var resultado =  await services.Inserir(contato, CancellationToken.None);

            //Assert

            Assert.True(resultado == idContato);

            _contatoRepository.Verify(c => c.Inserir
            (
                It.Is<Contato>(b => b.Equals(contato)),
                It.IsAny<CancellationToken>())
            , Times.Once());

            _regiaoDddRepository.Verify(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(contato.Telefone.Ddd))), Times.Once());
        }
    }
}
