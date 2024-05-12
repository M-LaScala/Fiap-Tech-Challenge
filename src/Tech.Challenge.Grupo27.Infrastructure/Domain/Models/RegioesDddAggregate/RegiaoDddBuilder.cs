using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tech.Challenge.Grupo27.Infrastructure.Domain.Models.RegioesDddAggregate
{
    internal static class RegiaoDddBuilder
    {
        public static void Build(EntityTypeBuilder<RegiaoDddEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Estado).HasColumnType("Varchar(2)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnType("Varchar(50)").IsRequired();
            builder.Property(x => x.Codigo).IsRequired();  
            builder.Property(x => x.DataDeCriacao).IsRequired().HasDefaultValue(DateTime.UtcNow); 
            builder.Property(x => x.DataDeAlteracao);

            builder.HasIndex(x => x.Codigo);            
            builder.ToTable("Tb_RegiaoDdd");
        }
    }
}
