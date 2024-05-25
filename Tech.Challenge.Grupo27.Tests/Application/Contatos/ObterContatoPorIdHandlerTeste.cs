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
    public class ObterContatoPorIdHandlerTeste
    {
        private readonly Mock<IContatoService> _contatoService;                
        private readonly CompareLogic _compareLogic;
        public ObterContatoPorIdHandlerTeste()
        {
            _contatoService = new Mock<IContatoService>();            
            _compareLogic = new CompareLogic();
        }

        // <summary>
        /// Obter Contato Por Id com sucesso.
        /// </summary>
        [Fact]
        public async Task ObterContatoPorId_IdValido_DeveRetornarSucesso()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            var contato = ContatoFixture.ObterContatoMock(idContato);
            var request = new ObterPorIdRequest(idContato);

            var resultadoEsperado = new ContatoResponse()
            {
                Sucesso = true,
                Mensagem = "contato encontrado",
                Data = new ObterContatoResponse
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
                 )

            };

            _contatoService.Setup(c => c.ObterPorId
            (
                It.Is<Guid>(x => x.Equals(idContato)))                
            ).ReturnsAsync(contato).Verifiable();

            var handler = new ObterContatoPorIdHandler(_contatoService.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.True(_compareLogic.Compare(resultado,resultadoEsperado).AreEqual);

            _contatoService.Verify(c => c.ObterPorId
            (
                It.Is<Guid>(x => x.Equals(idContato)))
            , Times.Once());         
        }

        // <summary>
        /// Obter Contato Por Id não encontrado.
        /// </summary>
        [Fact]
        public async Task ObterContatoPorId_IdNaoEncontrado_DeveRetornarNull()
        {
            //Arrange
            var idContato = Guid.NewGuid();
            Contato? contato = null;
            var request = new ObterPorIdRequest(idContato);

            var resultadoEsperado = new ContatoResponse()
            {
                Sucesso = false,
                Mensagem = $"Contato não encotrado para o Id: {request.Id}",
                Data = null
            };

            _contatoService.Setup(c => c.ObterPorId
            (
                It.Is<Guid>(x => x.Equals(idContato)))
            ).ReturnsAsync(contato).Verifiable();

            var handler = new ObterContatoPorIdHandler(_contatoService.Object);

            //Act
            var resultado = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.True(_compareLogic.Compare(resultado, resultadoEsperado).AreEqual);

            _contatoService.Verify(c => c.ObterPorId
            (
                It.Is<Guid>(x => x.Equals(idContato)))
            , Times.Once());
        }
    }
}
