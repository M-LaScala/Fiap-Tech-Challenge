namespace Tech.Challenge.Grupo27.Domain.Models.RegioesDddAggregate
{
    public interface IRegiaoDddRepository
    {
        ValueTask<RegiaoDdd?> ObterRegiaoPorCodigoDdd(int ddd);
    }
}
