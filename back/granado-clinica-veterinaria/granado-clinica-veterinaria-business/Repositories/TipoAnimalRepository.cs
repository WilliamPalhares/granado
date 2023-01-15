using granado_clinica_veterinaria_business.Interfaces;
using granado_clinica_veterinaria_domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace granado_clinica_veterinaria_business.Repositories
{
    public class TipoAnimalRepository : BaseRepository<TipoAnimalModel>, ITipoAnimalRepository
    {
        public TipoAnimalRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
