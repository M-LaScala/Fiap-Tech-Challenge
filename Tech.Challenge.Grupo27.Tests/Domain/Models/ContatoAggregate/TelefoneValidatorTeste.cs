using FluentValidation.TestHelper;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Shared.ValueObject;

namespace Tech.Challenge.Grupo27.Tests.Domain.Models.ContatoAggregate
{
    public class TelefoneValidatorTeste
    {
        [Fact]
        public void TelefoneValidator_TelefoneValidoDDDCom2NumCom9_DeveRetornarSucesso()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();

            //Act
            var result = telefoneValidator.Validate(new Telefone("13", "997843424"));

            //Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void TelefoneValidator_ComDadosNulos_DeveRetornarDDDeNumeroObrigatorios()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();

            //Act
            var result = telefoneValidator.Validate(new Telefone(null, null));

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains("Número é obrigatório.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("NUMERO_OBRIGATORIO", result.Errors.Select(x => x.ErrorCode));
            Assert.Contains("DDD é obrigatório.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("DDD_OBRIGATORIO", result.Errors.Select(x => x.ErrorCode));

        }

        [Fact]
        public void TelefoneValidator_TelefoneInvalido_DeveRetornarDDDeNumeroInvalidos()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();

            //Act
            var result = telefoneValidator.Validate(new Telefone("01", "785646198"));

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains("DDD de telefone inválido.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("DDD_INVALIDO", result.Errors.Select(x => x.ErrorCode));
            Assert.Contains("Número de telefone inválido.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("NUMERO_INVALIDO", result.Errors.Select(x => x.ErrorCode));

        }

        [Fact]
        public void TelefoneValidator_TelefoneUltrapassaMaximoCaractere_DeveRetornarDDDeNumeroMaximos()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();

            //Act
            var result = telefoneValidator.Validate(new Telefone("011", "7856461988956"));

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains("O número deve ter no máximo 10 caracteres.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("NUMERO_TAMANHO_MAXIMO", result.Errors.Select(x => x.ErrorCode));
            Assert.Contains("O DDD deve conter 2 caracteres.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("DDD_TAMANHO", result.Errors.Select(x => x.ErrorCode));

        }
        [Fact]
        public void TelefoneValidator_ComDDDVazio_DeveRetornarDDDObrigatorio()
        {
            // Arrange
            var telefoneValidator = new TelefoneValidator();

            // Act
            var result = telefoneValidator.Validate(new Telefone("", "9822775661"));

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains("DDD é obrigatório.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("DDD_OBRIGATORIO", result.Errors.Select(x => x.ErrorCode));
            Assert.Contains("O DDD deve conter 2 caracteres.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("DDD_TAMANHO", result.Errors.Select(x => x.ErrorCode));
            Assert.Contains("Número de telefone inválido.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("NUMERO_INVALIDO", result.Errors.Select(x => x.ErrorCode));
        }

        [Fact]
        public void TelefoneValidator_ComNumeroVazio_DeveRetornarNumeroObrigatorio()
        {
            // Arrange
            var telefoneValidator = new TelefoneValidator();

            // Act
            var result = telefoneValidator.Validate(new Telefone("13", ""));

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains("Número é obrigatório.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("NUMERO_OBRIGATORIO", result.Errors.Select(x => x.ErrorCode));
        }

        [Fact]
        public void TelefoneValidator_DDDCom3eNumeroCom11Caracteres_DeveRetornarDDDeNumeroMaximos()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();

            //Act
            var result = telefoneValidator.Validate(new Telefone("011", "01234567890"));

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains("O número deve ter no máximo 10 caracteres.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("NUMERO_TAMANHO_MAXIMO", result.Errors.Select(x => x.ErrorCode));
            Assert.Contains("O DDD deve conter 2 caracteres.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("DDD_TAMANHO", result.Errors.Select(x => x.ErrorCode));
        }
        [Fact]
        public void TelefoneValidator_DDDCom1eNumeroCom9Caracteres_DeveRetornarDDDInvalido()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();

            //Act
            var result = telefoneValidator.Validate(new Telefone("0", "123456789"));

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains("O DDD deve conter 2 caracteres.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("DDD_TAMANHO", result.Errors.Select(x => x.ErrorCode));
            Assert.Contains("DDD de telefone inválido.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("DDD_INVALIDO", result.Errors.Select(x => x.ErrorCode));
            Assert.Contains("Número de telefone inválido.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("NUMERO_INVALIDO", result.Errors.Select(x => x.ErrorCode));
        }
        [Fact]
        public void TelefoneValidator_DDDCom2EspacoeNumeroCom9Espacos_DeveRetornarInvalido()
        {
            //Arrange
            var telefoneValidator = new TelefoneValidator();

            //Act
            var result = telefoneValidator.Validate(new Telefone("  ", "         "));

            //Assert
            Assert.False(result.IsValid);
            Assert.Contains("Número é obrigatório.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("NUMERO_OBRIGATORIO", result.Errors.Select(x => x.ErrorCode));
            Assert.Contains("DDD é obrigatório.", result.Errors.Select(x => x.ErrorMessage));
            Assert.Contains("DDD_OBRIGATORIO", result.Errors.Select(x => x.ErrorCode));
        }
    }
}
