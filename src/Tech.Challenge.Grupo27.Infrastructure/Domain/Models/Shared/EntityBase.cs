namespace Tech.Challenge.Grupo27.Infrastructure.Domain.Models.Shared
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime? DataDeAlteracao { get; set; }

        public EntityBase()
        {
            this.Id = Guid.NewGuid();
            this.DataDeCriacao = DateTime.UtcNow;
        }
    }
}
