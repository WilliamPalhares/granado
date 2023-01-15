using granado_clinica_veterinaria_business.Interfaces;
using granado_clinica_veterinaria_domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace granado_clinica_veterinaria_business.Repositories
{
    public class AgendamentoRepository : BaseRepository<AgendamentoModel>, IAgendamentoRepository
    {
        public AgendamentoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
