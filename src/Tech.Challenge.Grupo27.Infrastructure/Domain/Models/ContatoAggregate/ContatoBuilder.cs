using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tech.Challenge.Grupo27.Infrastructure.Domain.Models.ContatoAggregate
{
    internal static class ContatoBuilder
    {
        public static void Build(EntityTypeBuilder<ContatoEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("Varchar(80)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("Varchar(10)").IsRequired();
            builder.Property(x => x.Ddd).HasColumnType("Varchar(2)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("Varchar(40)").IsRequired();
            builder.Property(x => x.DataDeCriacao).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.DataDeAlteracao).HasColumnType("DateTime");
            builder.ToTable("Tb_Contato");
        }
    }
}
