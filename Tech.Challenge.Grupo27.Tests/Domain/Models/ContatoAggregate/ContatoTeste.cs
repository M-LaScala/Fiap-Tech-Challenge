using System.ComponentModel.DataAnnotations;
using Tech.Challenge.Grupo27.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Domain.Shared.ValueObject;

namespace Tech.Challenge.Grupo27.Tests.Domain.Models.ContatoAggregate
{
    public class ContatoTeste
    {
        /// <summary>
        /// Criação de contato padrão.
        /// </summary>
        [Fact]
        public void Contato_ComTodosCamposValidos_DeveRetornarValido()
        {
            Telefone telefone = new Telefone("13", "997843424");
            Contato contato = new Contato("Pedro Luiz", "pedro_2004@gmail.com", telefone);

            Assert.True(contato.Valid);
        }

        [Fact]
        public void Contato_ComDadosValidosPreenchidos_DeveRetornarOK()
        {
            // Arrange
            string nome = "John Doe";
            string email = "johndoe@example.com";
            Telefone telefone = new Telefone("12", "3456789");

            // Act
            var contato = new Contato(nome, email, telefone);

            // Assert
            Assert.NotNull(contato);
            Assert.Equal(nome, contato.Nome);
            Assert.Equal(email, contato.Email);
            Assert.Equal(telefone, contato.Telefone);
        }

        /// <summary>
        /// Criação de contato com e-mail invalido.
        /// </summary>
        [Fact]
        public void Contato_ComEmailInvalido_DeveRetornarInvalido()
        {
            Telefone telefone = new Telefone("13", "997843424");
            Contato contato = new Contato("Pedro Luiz", "email.com.br", telefone);

            Assert.False(contato.Valid);
        }

        /// <summary>
        /// Criação de contato com DDD invalido.
        /// </summary>
        [Fact]
        public void Contato_ComDDDInvalido_DeveRetornarInvalido()
        {
            Telefone telefone = new Telefone("555", "983243424");
            Contato contato = new Contato("Pedro Luiz", "pedro_2004@gmail.com", telefone);
            Assert.False(contato.Valid);
        }
    }
}

