using KellermanSoftware.CompareNetObjects;
using Moq;
using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Dtos;
using Tech.Challenge.Grupo27.Application.Contatos.ObterContato.Handler_;
using Tech.Challenge.Grupo27.Application.Contatos.ViewModels;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Services;
using Tech.Challenge.Grupo27.Tests.Fixtures;

namespace Tech.Challenge.Grupo27.Tests.Application.Contatos
{
    public class ObterContatosPorDddHandlerTeste
    {
        private readonly Mock<IContatoService> _contatoService;        
        private readonly CompareLogic _compareLogic;
        public ObterContatosPorDddHandlerTeste()
        {
            _contatoService = new Mock<IContatoService>();            
            _compareLogic = new CompareLogic();
        }

        // <summary>
        /// Obter Contato Por DDD com sucesso.
        /// </summary>
        [Fact]
        public async Task ObterContatoPorDDD_DddValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var ddd = 11;
            var contato = ContatoFixture.ObterContatoMock(idContato);
            var contatos = new List<Contato>() { contato };
            var request = new ObterPorDddRequest(ddd);
            var contatosResponse = new List<ObterContatoResponse>() { new ObterContatoResponse
                    (
                        contato.Id,
                        contato.Nome,
                        contato.Email,
                        new TelefoneResponse
                        (
                            contato?.Telefone?.Numero,
                            contato?.Telefone?.Ddd,
                            contato?.Telefone?.Estado,
                            contato?.Telefone?.Regiao
                        )
                    ) };

            var resultadoEsperado = new ContatoResponse()
            {
                Sucesso = true,
                Mensagem = "contato encontrado",
                Data = contatosResponse
            };

           

            _contatoService.Setup(c => c.ObterPorDdd
            (
                It.Is<string?>(x => _compareLogic.Compare(x, ddd.ToString()).AreEqual))
            ).ReturnsAsync(contatos).Verifiable();

            var handler = new ObterContatosPorDddHandler(_contatoService.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.True(_compareLogic.Compare(resultado, resultadoEsperado).AreEqual);

            _contatoService.Verify(c => c.ObterPorDdd
            (
                 It.Is<string?>(x => _compareLogic.Compare(x, ddd.ToString()).AreEqual))
            , Times.Once());
        }

        // <summary>
        /// Obter Contato Por DDD não encontrado.
        /// </summary>
        [Fact]
        public async Task ObterContatoPorDDD_DddEncontrado_DeveRetornarNull()
        {
            //Arrange            
            var ddd = 11;            
            List<Contato>? contatos = null;
            var request = new ObterPorDddRequest(ddd);           

            var resultadoEsperado = new ContatoResponse()
            {
                Sucesso = false,
                Mensagem = $"Contato não encotrado para o DDD: {request?.Ddd}",
                Data = null
            };

            _contatoService.Setup(c => c.ObterPorDdd
            (
                It.Is<string?>(x => _compareLogic.Compare(x, ddd.ToString()).AreEqual))
            ).ReturnsAsync(contatos).Verifiable();

            var handler = new ObterContatosPorDddHandler(_contatoService.Object);

            //Act
            var resultado = await handler.Handle(request!, CancellationToken.None);

            //Assert
            Assert.True(_compareLogic.Compare(resultado, resultadoEsperado).AreEqual);

            _contatoService.Verify(c => c.ObterPorDdd
            (
                 It.Is<string?>(x => _compareLogic.Compare(x, ddd.ToString()).AreEqual))
            , Times.Once());
        }
    }
}
