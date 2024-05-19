using Microsoft.EntityFrameworkCore;
using Tech.Challenge.Grupo27.Domain.Models.RegioesDddAggregate;
using Tech.Challenge.Grupo27.Infrastructure.EntityFrameworkCore;

namespace Tech.Challenge.Grupo27.Infrastructure.Domain.Models.RegioesDddAggregate
{
    public class RegiaoDddRepository : IRegiaoDddRepository
    {
        private readonly TechChallengeGrupo27Context _context;

        public RegiaoDddRepository(TechChallengeGrupo27Context context)
        {
            _context = context;
        }

        public async ValueTask<RegiaoDdd?> ObterRegiaoPorCodigoDdd(int ddd)
        {
            var regiaoEntity = await _context.RegioesDdds.FirstOrDefaultAsync(c => c.Codigo == ddd);

            if (regiaoEntity is null) return default;

            return MapearRegiaoDdd(regiaoEntity);
        }
        private static RegiaoDdd MapearRegiaoDdd(RegiaoDddEntity regiaoEntity)
        {
            return new RegiaoDdd(regiaoEntity.Id, regiaoEntity.Codigo, regiaoEntity.Estado, regiaoEntity.Descricao);
        }
    }
}
