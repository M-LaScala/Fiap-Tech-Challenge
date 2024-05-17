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
        public void ValidaCriacaoContato()
        {
            Telefone telefone = new Telefone("13", "997843424");
            Contato contato = new Contato("Pedro Luiz", "pedro_2004@gmail.com", telefone);

            Assert.True(contato.Valid);
        }

        /// <summary>
        /// Criação de contato com e-mail invalido.
        /// </summary>
        [Fact]
        public void ValidaErroCriacaoContatoEmail()
        {
            Telefone telefone = new Telefone("13", "997843424");
            Contato contato = new Contato("Pedro Luiz", "e-mail", telefone);

            Assert.False(contato.Valid);
        }

        /// <summary>
        /// Criação de contato com DDD invalido.
        /// </summary>
        [Fact]
        public void ValidaErroCriacaoTelefoneDDD()
        {
            Telefone telefone = new Telefone("555", "983243424");
            Contato contato = new Contato("Pedro Luiz", "pedro_2004@gmail.com", telefone);
            Assert.False(contato.Valid);
        }
    }
}
