using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Shared.ValueObject;

namespace Tech.Challenge.Grupo27.Tests.Domain.Models.ContatoAggregate
{
    public class ContatoValidatorTeste
    {
        /// <summary>
        /// Contato Validator
        /// </summary>
        [Fact]
        public void ContatoValidator_ContatoValido_DeveRetornarSucesso()
        {
            //Arrange
            var contatoValidator = new ContatoValidator();

            //Act
            var contatoRsult = contatoValidator.Validate(ObterContatoMock("Mario José Silva","jm@gmail.com"));

            //Assert
            Assert.True(contatoRsult.IsValid);
        }

        /// <summary>
        /// Contato Validator nome e e-mail Obrigatório
        /// </summary>
        [Fact]
        public void ContatoValidator_NomeEhEmailNull_DeveRetornarErro()
        {
            //Arrange
            var contatoValidator = new ContatoValidator();

            //Act
            var contatoRsult = contatoValidator.Validate(ObterContatoMock(null,null));

            //Assert
            Assert.False(contatoRsult.IsValid);
            Assert.Contains("Nome é obrigatório.", contatoRsult.Errors.Select(e => e.ErrorMessage));
            Assert.Contains("E-mail é obrigatório.", contatoRsult.Errors.Select(e => e.ErrorMessage));
        }

        /// <summary>
        /// Contato Validator Email Invalido
        /// </summary>
        [Theory]
        [InlineData("joao.silva&.com")]
        [InlineData("joao.br#.com.br")]
        [InlineData("xxxxx.br")]
        [InlineData("joao.br.com@")]
        public void ContatoValidator_EmailInvalido_DeveRetornarErro(string email)
        {
            //Arrange
            var contatoValidator = new ContatoValidator();            
            
            //Act
            var contatoRsult = contatoValidator.Validate(ObterContatoMock("Marcos Silva", email));

            //Assert
            Assert.False(contatoRsult.IsValid);
            Assert.Contains("E-mail inválido.", contatoRsult.Errors.Select(e => e.ErrorMessage));
        }



        private Contato ObterContatoMock(string nome, string email)
        {
            Telefone telefone = new Telefone("13", "997843424");
            Contato contato = new Contato(nome, email, telefone);
            return contato; 
        }
    }
}
