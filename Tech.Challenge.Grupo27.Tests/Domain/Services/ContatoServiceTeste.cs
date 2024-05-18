using Moq;
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

        // <summary>
        /// Atualizar de contato padrão.
        /// </summary>
        [Fact]
        public async Task Atualizar_ContatoValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = _contatoFixture.ObterContatoMock(idContato);

            _contatoRepository.Setup(c => c.Atualizar
            (
                It.Is<Contato>(b => b.Equals(contato)),
                It.IsAny<CancellationToken>())
            ).Verifiable();

            _regiaoDddRepository.Setup(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(contato.Telefone.Ddd)))).ReturnsAsync(_regiaoDddFixture.ObterRegiaoDddMock());

            var services = new ContatoService(_contatoRepository.Object, _regiaoDddRepository.Object, _notificacaoContext.Object);

            //Act
            await services.Atualizar(contato, CancellationToken.None);

            //Assert            

            _contatoRepository.Verify(c => c.Atualizar
            (
                It.Is<Contato>(b => b.Equals(contato)),
                It.IsAny<CancellationToken>())
            , Times.Once());

            _regiaoDddRepository.Verify(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(contato.Telefone.Ddd))), Times.Once());
        }

        // <summary>
        /// Obter de contato por DDD.
        /// </summary>
        [Fact]
        public async Task ObterPorDdd_DddValido_DeveRetornarSucesso()
        {
            //Arrange            
            var contatos = _contatoFixture.ObterContatosMock();
            var regiao = _regiaoDddFixture.ObterRegiaoDddMock();
            var ddd = contatos.FirstOrDefault().Telefone.Ddd;
            _contatoRepository.Setup(c => c.ObterPorDdd
            (
                It.Is<string>(b => b.Equals(ddd))

            )).ReturnsAsync(contatos).Verifiable();

            _regiaoDddRepository.Setup(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(ddd)))).ReturnsAsync(regiao);

            foreach (var contato in contatos)
            {
                contato.Telefone.AdicionarRegiaoDoDdd(regiao.Descricao, regiao.Estado);
            }           

            var services = new ContatoService(_contatoRepository.Object, _regiaoDddRepository.Object, _notificacaoContext.Object);

            //Act
            var resultado = await services.ObterPorDdd(ddd);

            //Assert            

            Assert.NotNull(resultado);
            Assert.True(resultado.Count() == contatos.Count());

            _contatoRepository.Verify(c => c.ObterPorDdd
            (
                It.Is<string>(b => b.Equals(ddd))

            )
            , Times.Once());

            _regiaoDddRepository.Verify(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(ddd))), Times.Once());
        }

        // <summary>
        /// Obter de contato por Id.
        /// </summary>
        [Fact]
        public async Task ObterPorId_IdValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = _contatoFixture.ObterContatoMock(idContato);
            var regiao = _regiaoDddFixture.ObterRegiaoDddMock();
            contato.Telefone.AdicionarRegiaoDoDdd(regiao.Descricao, regiao.Estado);
            _contatoRepository.Setup(c => c.ObterPorId
            (
                It.Is<Guid>(b => b.Equals(idContato))

            )).ReturnsAsync(contato).Verifiable();

            _regiaoDddRepository.Setup(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(contato.Telefone.Ddd)))).ReturnsAsync(regiao);

            var services = new ContatoService(_contatoRepository.Object, _regiaoDddRepository.Object, _notificacaoContext.Object);

            //Act
            var resultado = await services.ObterPorId(idContato);

            //Assert            

            Assert.NotNull(resultado);
            Assert.True(resultado.Id == contato.Id);

            _contatoRepository.Verify(c => c.ObterPorId
            (
                It.Is<Guid>(b => b.Equals(idContato))

            )
            , Times.Once());

            _regiaoDddRepository.Verify(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(contato.Telefone.Ddd))), Times.Once());
        }

        // <summary>
        /// Delete contato.
        /// </summary>
        [Fact]
        public async Task Delete_IdValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = _contatoFixture.ObterContatoMock(idContato);                        
           
            _contatoRepository.Setup(c => c.Delete
            (
                It.Is<Guid>(b => b.Equals(idContato)),
                It.IsAny<CancellationToken>())

            ).ReturnsAsync(contato).Verifiable();          

            var services = new ContatoService(_contatoRepository.Object, _regiaoDddRepository.Object, _notificacaoContext.Object);

            //Act
            var resultado = await services.Delete(idContato, CancellationToken.None);

            //Assert            

            Assert.NotNull(resultado);
            Assert.True(resultado.Id == contato.Id);

            _contatoRepository.Verify(c=> c.Delete
            (
                It.Is<Guid>(b => b.Equals(idContato)),
                It.IsAny<CancellationToken>()

            )
            , Times.Once());            
        }
    }
}
