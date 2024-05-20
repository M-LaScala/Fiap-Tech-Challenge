using Moq;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Models.RegioesDddAggregate;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Domain.Shared.Exceptions;
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
            var contato = ContatoFixture.ObterContatoMock(idContato);

            _contatoRepository.Setup(c=> c.Inserir
            (
                It.Is<Contato>(b=> b.Equals(contato)),
                It.IsAny<CancellationToken>())
            ).ReturnsAsync(idContato).Verifiable();

            if (contato != null && contato.Telefone != null && int.TryParse(contato.Telefone.Ddd, out int ddd))
            {
                _regiaoDddRepository.Setup(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == ddd)))
                                    .ReturnsAsync(RegiaoDddFixture.ObterRegiaoDddMock());
            }
            else
            {
                // Lidar com o caso em que contato ou contato.Telefone é nulo
                throw new InvalidOperationException("Contato ou Telefone está nulo.");
            }

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

            if (contato?.Telefone?.Ddd != null)
            {
                int dddValue = Convert.ToInt32(contato.Telefone.Ddd);
                _regiaoDddRepository.Verify(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == dddValue)), Times.Once());
            }
            else
            {
                // Lidar com o caso em que contato ou contato.Telefone ou contato.Telefone.Ddd é nulo
                throw new InvalidOperationException("Contato, Telefone ou DDD está nulo.");
            }
       }

        // <summary>
        /// Criação de contato com DDD inexistente deve retornar erro.
        /// </summary>
        [Fact]
        public async Task Inserir_ContatoDDDInexistente_DeveRetornarErro()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = ContatoFixture.ObterContatoMock(idContato);

            _contatoRepository.Setup(c => c.Inserir
            (
                It.Is<Contato>(b => b.Equals(contato)),
                It.IsAny<CancellationToken>())
            ).ReturnsAsync(idContato).Verifiable();

            if (contato?.Telefone?.Ddd != null)
            {
                int dddValue = Convert.ToInt32(contato.Telefone.Ddd);
                _regiaoDddRepository.Setup(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == dddValue))).ReturnsAsync((RegiaoDdd?)null);
            }
            else
            {
                // Lidar com o caso em que contato ou contato.Telefone ou contato.Telefone.Ddd é nulo
                throw new InvalidOperationException("Contato, Telefone ou DDD está nulo.");
            }

            _notificacaoContext.Setup(n => n.AddNotificacao("DDD_INEXISTENTE", "Não foi possível encontrar uma região para o DDD informado")).Verifiable();


            var services = new ContatoService(_contatoRepository.Object, _regiaoDddRepository.Object, _notificacaoContext.Object);

            //Act
            await services.Inserir(contato, CancellationToken.None);

            //Assert
            
            _contatoRepository.Verify(c => c.Inserir
            (
                It.Is<Contato>(b => b.Equals(contato)),
                It.IsAny<CancellationToken>())
            , Times.Never());

            if (contato?.Telefone?.Ddd != null)
            {
                int dddValue = Convert.ToInt32(contato.Telefone.Ddd);
                _regiaoDddRepository.Verify(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == dddValue)), Times.Once());
            }
            else
            {
                // Lidar com o caso em que contato ou contato.Telefone ou contato.Telefone.Ddd é nulo
                throw new InvalidOperationException("Contato, Telefone ou DDD está nulo.");
            }

            _notificacaoContext.Verify(n => n.AddNotificacao("DDD_INEXISTENTE", "Não foi possível encontrar uma região para o DDD informado"), Times.Once());
        }

        // <summary>
        /// Criação de contato com contato null deve retornar erro.
        /// </summary>
        [Fact]
        public async Task Inserir_ContatoNull_DeveRetornarErro()
        {
            //Arrange            
            Contato? contato = null;                     

            _notificacaoContext.Setup(n => n.AddNotificacao("CONTATO_NULLO", "O contato deve ser preenchido corretamente")).Verifiable();


            var services = new ContatoService(_contatoRepository.Object, _regiaoDddRepository.Object, _notificacaoContext.Object);

            //Act
            await services.Inserir(contato, CancellationToken.None);

            //Assert
            _contatoRepository.Verify(c => c.Inserir
            (
                It.Is<Contato>(b => b.Equals(contato)),
                It.IsAny<CancellationToken>())
            , Times.Never());
            _regiaoDddRepository.Verify(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(contato.Telefone.Ddd))), Times.Never());

            _notificacaoContext.Verify(n => n.AddNotificacao("CONTATO_NULLO", "O contato deve ser preenchido corretamente"), Times.Once());
        }

        // <summary>
        /// Atualizar de contato padrão.
        /// </summary>
        [Fact]
        public async Task Atualizar_ContatoValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = ContatoFixture.ObterContatoMock(idContato);

            _contatoRepository.Setup(c => c.Atualizar
            (
                It.Is<Contato>(b => b.Equals(contato)),
                It.IsAny<CancellationToken>())
            ).Verifiable();

            if (contato?.Telefone?.Ddd != null)
            {
                int dddValue = Convert.ToInt32(contato.Telefone.Ddd);
                _regiaoDddRepository.Setup(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == dddValue))).ReturnsAsync(RegiaoDddFixture.ObterRegiaoDddMock());
            }
            else
            {
                // Lidar com o caso em que contato ou contato.Telefone ou contato.Telefone.Ddd é nulo
                throw new InvalidOperationException("Contato, Telefone ou DDD está nulo.");
            }

            var services = new ContatoService(_contatoRepository.Object, _regiaoDddRepository.Object, _notificacaoContext.Object);

            //Act
            await services.Atualizar(contato, CancellationToken.None);

            //Assert            

            _contatoRepository.Verify(c => c.Atualizar
            (
                It.Is<Contato>(b => b.Equals(contato)),
                It.IsAny<CancellationToken>())
            , Times.Once());

            if (contato?.Telefone?.Ddd != null)
            {
                int dddValue = Convert.ToInt32(contato.Telefone.Ddd);
                _regiaoDddRepository.Verify(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == dddValue)), Times.Once());
            }
            else
            {
                // Lidar com o caso em que contato ou contato.Telefone ou contato.Telefone.Ddd é nulo
                throw new InvalidOperationException("Contato, Telefone ou DDD está nulo.");
            }

        }

        // <summary>
        /// Obter de contato por DDD.
        /// </summary>
        [Fact]
        public async Task ObterPorDdd_DddValido_DeveRetornarSucesso()
        {
            //Arrange            
            var contatos = ContatoFixture.ObterContatosMock();
            var regiao = RegiaoDddFixture.ObterRegiaoDddMock();
            var ddd = contatos.FirstOrDefault()!.Telefone!.Ddd;
            _contatoRepository.Setup(c => c.ObterPorDdd
            (
                It.Is<string>(b => b.Equals(ddd))

            )).ReturnsAsync(contatos).Verifiable();

            _regiaoDddRepository.Setup(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(ddd)))).ReturnsAsync(regiao);

            foreach (var contato in contatos)
            {
                if (contato!.Telefone != null)
                {
                    contato.Telefone.AdicionarRegiaoDoDdd(regiao.Descricao, regiao.Estado);
                }
                else
                {
                    // Lidar com o caso em que contato ou contato.Telefone ou contato.Telefone.Ddd é nulo
                    throw new InvalidOperationException("Contato, Telefone ou DDD está nulo.");
                }
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
            var contato = ContatoFixture.ObterContatoMock(idContato);
            var regiao = RegiaoDddFixture.ObterRegiaoDddMock();
            contato!.Telefone!.AdicionarRegiaoDoDdd(regiao.Descricao, regiao.Estado);
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
        /// Obter de contato por Id não encontrado.
        /// </summary>
        [Fact]
        public async Task ObterPorId_IdNaoEncontrado_DeveRetornarNull()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            Contato? contato = null;            
           
            _contatoRepository.Setup(c => c.ObterPorId
            (
                It.Is<Guid>(b => b.Equals(idContato))

            )).ReturnsAsync(contato).Verifiable();            

            var services = new ContatoService(_contatoRepository.Object, _regiaoDddRepository.Object, _notificacaoContext.Object);

            //Act
            var resultado = await services.ObterPorId(idContato);

            //Assert            

            Assert.Null(resultado);            

            _contatoRepository.Verify(c => c.ObterPorId
            (
                It.Is<Guid>(b => b.Equals(idContato))

            )
            , Times.Once());

            _regiaoDddRepository.Verify(c => c.ObterRegiaoPorCodigoDdd(It.Is<int>(c => c == Convert.ToInt32(contato.Telefone.Ddd))), Times.Never());
        }

        // <summary>
        /// Delete contato.
        /// </summary>
        [Fact]
        public async Task Delete_IdValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = ContatoFixture.ObterContatoMock(idContato);                        
           
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

        // <summary>
        /// Delete contato Id não retorna conta.
        /// </summary>
        [Fact]
        public async Task Delete_IdNaoEncontrado_DeveRetornarNull()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            Contato? contato = null;

            _contatoRepository.Setup(c => c.Delete
            (
                It.Is<Guid>(b => b.Equals(idContato)),
                It.IsAny<CancellationToken>())

            ).ReturnsAsync(contato).Verifiable();

            var services = new ContatoService(_contatoRepository.Object, _regiaoDddRepository.Object, _notificacaoContext.Object);

            //Act
            var resultado = await services.Delete(idContato, CancellationToken.None);

            //Assert            

            Assert.Null(resultado);            

            _contatoRepository.Verify(c => c.Delete
            (
                It.Is<Guid>(b => b.Equals(idContato)),
                It.IsAny<CancellationToken>()

            )
            , Times.Once());
        }
    }
}
