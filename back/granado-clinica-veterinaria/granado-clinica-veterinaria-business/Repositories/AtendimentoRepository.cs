using granado_clinica_veterinaria_business.Interfaces;
using granado_clinica_veterinaria_domain.Models;
using Microsoft.Extensions.Logging;

namespace granado_clinica_veterinaria_business.Repositories
{
    public class AtendimentoRepository : BaseRepository<AtendimentoModel>, IAtendimentoRepository
    {
        public AtendimentoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
