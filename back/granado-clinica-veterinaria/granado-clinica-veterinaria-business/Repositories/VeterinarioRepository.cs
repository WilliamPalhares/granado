using granado_clinica_veterinaria_business.Interfaces;
using granado_clinica_veterinaria_domain.Models;
using Microsoft.Extensions.Logging;

namespace granado_clinica_veterinaria_business.Repositories
{
    public class VeterinarioRepository : BaseRepository<VeterinarioModel>, IVeterinarioRepository
    {
        public VeterinarioRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
