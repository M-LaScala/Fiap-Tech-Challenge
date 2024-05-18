using Microsoft.EntityFrameworkCore;
using Tech.Challenge.Grupo27.Infrastructure.Domain.Models.ContatoAggregate;
using Tech.Challenge.Grupo27.Infrastructure.Domain.Models.RegioesDddAggregate;

namespace Tech.Challenge.Grupo27.Infrastructure.EntityFrameworkCore
{
    public class TechChallengeGrupo27Context : DbContext
    {
        private readonly DbOptions _dbOptions;

        public DbSet<ContatoEntity> Contatos { get; set; }

        public DbSet<RegiaoDddEntity> RegioesDdds { get; set; }

        public TechChallengeGrupo27Context() { }
        public TechChallengeGrupo27Context(DbContextOptions<TechChallengeGrupo27Context> options, DbOptions dbOptions) : base(options)
        {
            _dbOptions = dbOptions ?? throw new ArgumentNullException(nameof(dbOptions));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbOptions.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!string.IsNullOrEmpty(_dbOptions.Shema))
                modelBuilder.HasDefaultSchema(_dbOptions.Shema.Replace(".", ""));

            ContatoBuilder.Build(modelBuilder.Entity<ContatoEntity>());
            RegiaoDddBuilder.Build(modelBuilder.Entity<RegiaoDddEntity>());
            modelBuilder.Entity<RegiaoDddEntity>().HasData
            (
                new RegiaoDddEntity(11, "Sudeste", "SP"),
                new RegiaoDddEntity(12, "Sudeste", "SP"),
                new RegiaoDddEntity(13, "Sudeste", "SP"),
                new RegiaoDddEntity(14, "Sudeste", "SP"),
                new RegiaoDddEntity(15, "Sudeste", "SP"),
                new RegiaoDddEntity(16, "Sudeste", "SP"),
                new RegiaoDddEntity(17, "Sudeste", "SP"),
                new RegiaoDddEntity(18, "Sudeste", "SP"),
                new RegiaoDddEntity(19, "Sudeste", "SP"),
                new RegiaoDddEntity(21, "Sudeste", "RJ"),
                new RegiaoDddEntity(22, "Sudeste", "RJ"),
                new RegiaoDddEntity(24, "Sudeste", "RJ"),
                new RegiaoDddEntity(27, "Sudeste", "ES"),
                new RegiaoDddEntity(28, "Sudeste", "ES"),
                new RegiaoDddEntity(31, "Sudeste", "MG"),
                new RegiaoDddEntity(32, "Sudeste", "MG"),
                new RegiaoDddEntity(33, "Sudeste", "MG"),
                new RegiaoDddEntity(34, "Sudeste", "MG"),
                new RegiaoDddEntity(35, "Sudeste", "MG"),
                new RegiaoDddEntity(37, "Sudeste", "MG"),
                new RegiaoDddEntity(38, "Sudeste", "MG"),

                new RegiaoDddEntity(41, "Sul", "PR"),
                new RegiaoDddEntity(42, "Sul", "PR"),
                new RegiaoDddEntity(43, "Sul", "PR"),
                new RegiaoDddEntity(44, "Sul", "PR"),
                new RegiaoDddEntity(45, "Sul", "PR"),
                new RegiaoDddEntity(46, "Sul", "PR"),
                new RegiaoDddEntity(47, "Sul", "SC"),
                new RegiaoDddEntity(48, "Sul", "SC"),
                new RegiaoDddEntity(49, "Sul", "SC"),
                new RegiaoDddEntity(51, "Sul", "RS"),
                new RegiaoDddEntity(53, "Sul", "RS"),
                new RegiaoDddEntity(54, "Sul", "RS"),
                new RegiaoDddEntity(55, "Sul", "RS"),

                new RegiaoDddEntity(61, "Centro-Oeste", "MG"),
                new RegiaoDddEntity(62, "Centro-Oeste", "GO"),
                new RegiaoDddEntity(64, "Centro-Oeste", "GO"),
                new RegiaoDddEntity(65, "Centro-Oeste", "MT"),
                new RegiaoDddEntity(66, "Centro-Oeste", "MT"),
                new RegiaoDddEntity(67, "Centro-Oeste", "MS"),

                new RegiaoDddEntity(63, "Norte", "TO"),
                new RegiaoDddEntity(68, "Norte", "AC"),
                new RegiaoDddEntity(69, "Norte", "RO"),
                new RegiaoDddEntity(96, "Norte", "AP"),
                new RegiaoDddEntity(92, "Norte", "AM"),
                new RegiaoDddEntity(97, "Norte", "AM"),
                new RegiaoDddEntity(91, "Norte", "PA"),
                new RegiaoDddEntity(93, "Norte", "PA"),
                new RegiaoDddEntity(94, "Norte", "PA"),
                new RegiaoDddEntity(95, "Norte", "RR"),

                new RegiaoDddEntity(71, "Nordeste", "BA"),
                new RegiaoDddEntity(73, "Nordeste", "BA"),
                new RegiaoDddEntity(74, "Nordeste", "BA"),
                new RegiaoDddEntity(75, "Nordeste", "BA"),
                new RegiaoDddEntity(77, "Nordeste", "BA"),
                new RegiaoDddEntity(85, "Nordeste", "CE"),
                new RegiaoDddEntity(88, "Nordeste", "CE"),
                new RegiaoDddEntity(98, "Nordeste", "MA"),
                new RegiaoDddEntity(99, "Nordeste", "MA"),
                new RegiaoDddEntity(83, "Nordeste", "PB"),
                new RegiaoDddEntity(81, "Nordeste", "PE"),
                new RegiaoDddEntity(87, "Nordeste", "PE"),
                new RegiaoDddEntity(86, "Nordeste", "PI"),
                new RegiaoDddEntity(89, "Nordeste", "PI"),
                new RegiaoDddEntity(84, "Nordeste", "RN"),
                new RegiaoDddEntity(82, "Nordeste", "AL"),
                new RegiaoDddEntity(79, "Nordeste", "SE")
                );
            base.OnModelCreating(modelBuilder);


        }


    }
}
