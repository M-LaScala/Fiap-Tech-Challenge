using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Shared.ValueObject;

namespace Tech.Challenge.Grupo27.Tests.Domain.Models.ContatoAggregate
{
    public class TelefoneValidatorTeste
    {
        /// <summary>
        /// Telefone válido
        /// </summary>
        [Fact]
        public void TelefoneValidator_TelefoneValido_DeveRetornarSucesso()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();

            //Act
            var telefoneRsult = telefoneValidator.Validate(new Telefone("13", "997843424"));
            
            //Assert
            Assert.True(telefoneRsult.IsValid);                       
        }

        /// <summary>
        /// Telefone Obrigatório
        /// </summary>
        [Fact]
        public void TelefoneValidator_TelefoneObrigatorio_DeveRetornarErro()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();
            
            //Act
            var telefoneRsult = telefoneValidator.Validate(new Telefone(null, null));

            //Assert
            Assert.False(telefoneRsult.IsValid);
            Assert.Contains("Número é obrigatório.", telefoneRsult.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("DDD é obrigatório.", telefoneRsult.Errors.Select(x => x.ErrorMessage));

        }

        /// <summary>
        /// Telefone Inválido
        /// </summary>
        [Fact]
        public void TelefoneValidator_TelefoneInvalido_DeveRetornarErro()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();

            //Act
            var telefoneRsult = telefoneValidator.Validate(new Telefone("01", "785646198"));

            //Assert
            Assert.False(telefoneRsult.IsValid);
            Assert.Contains("DDD de telefone inválido.", telefoneRsult.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("Número de telefone inválido.", telefoneRsult.Errors.Select(x => x.ErrorMessage));

        }

        /// <summary>
        /// Telefone Inválido
        /// </summary>
        [Fact]
        public void TelefoneValidator_TelefoneUltrapassaMaximoCaractere_DeveRetornarErro()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();

            //Act
            var telefoneRsult = telefoneValidator.Validate(new Telefone("011", "7856461988956"));

            //Assert
            Assert.False(telefoneRsult.IsValid);
            Assert.Contains("O número deve ter no máximo 10 caracteres.", telefoneRsult.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("O DDD deve conter 2 caracteres.", telefoneRsult.Errors.Select(x => x.ErrorMessage));

        }
    }
}
