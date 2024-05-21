using System;
using Xunit;
using Tech.Challenge.Grupo27.Domain.Models.RegioesDddAggregate;

namespace Tech.Challenge.Grupo27.Tests
{
    public class RegiaoDddTests
    {
        [Fact]
        public void RegiaoDdd_Constructor_SetsProperties()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            int codigo = 123;
            string estado = "Sao Paulo";
            string descricao = "Regiao DDD";

            // Act
            RegiaoDdd regiaoDdd = new RegiaoDdd(id, codigo, estado, descricao);

            // Assert
            Assert.Equal(id, regiaoDdd.Id);
            Assert.Equal(codigo, regiaoDdd.Codigo);
            Assert.Equal(estado, regiaoDdd.Estado);
            Assert.Equal(descricao, regiaoDdd.Descricao);
        }
    }
}
