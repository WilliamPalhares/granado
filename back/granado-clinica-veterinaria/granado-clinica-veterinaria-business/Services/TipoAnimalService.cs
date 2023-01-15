using AutoMapper;
using granado_clinica_veterinaria_business.Interfaces;
using granado_clinica_veterinaria_business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace granado_clinica_veterinaria_business.Services
{
    public class TipoAnimalService
    {
        protected readonly ITipoAnimalRepository tipoAnimalRepository;
        protected readonly IMapper mapper;

        public TipoAnimalService(ITipoAnimalRepository tipoAnimalRepository, IMapper mapper)
        {
            this.tipoAnimalRepository = tipoAnimalRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TipoAnimalViewModel>> GetListTipoAsync()
        {
            try
            {
                return mapper.Map<IEnumerable<TipoAnimalViewModel>>(await tipoAnimalRepository.GetListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TipoAnimalViewModel> GetTipoAsync(Int64 Id)
        {
            try
            {
                return mapper.Map<TipoAnimalViewModel>(await tipoAnimalRepository.GetObjectAsync(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
