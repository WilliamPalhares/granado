using AutoMapper;
using granado_clinica_veterinaria_business.Interfaces;
using granado_clinica_veterinaria_business.ViewModels;
using granado_clinica_veterinaria_domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace granado_clinica_veterinaria_business.Services
{
    public class AnimalService
    {
        protected readonly IAnimalRepository animalRepository;
        protected readonly IMapper mapper;

        public AnimalService(IAnimalRepository animalRepository, IMapper mapper)
        {
            this.animalRepository = animalRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AnimalViewModel>> GetListAnimalAsync()
        {
            try
            {
                return mapper.Map<IEnumerable<AnimalViewModel>>(await animalRepository.GetListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AnimalViewModel> GetAnimalAsync(Int64 Id)
        {
            try
            {
                return mapper.Map<AnimalViewModel>(await animalRepository.GetObjectAsync(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertAsync(AnimalViewModel viewModel)
        {
            try
            {
                AnimalModel model = mapper.Map<AnimalModel>(viewModel);
                model.DataCadastro = DateTime.Now;

                await animalRepository.InsertAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertAsync(AnimalModel model)
        {
            try
            {
                model.DataCadastro = DateTime.Now;
                await animalRepository.InsertAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(AnimalViewModel viewModel)
        {
            try
            {
                AnimalModel modelMapper = mapper.Map<AnimalModel>(viewModel);

                AnimalModel model = await animalRepository.GetObjectAsync(viewModel.Id);
                model.Nome = modelMapper.Nome;
                model.DataCadastro = modelMapper.DataCadastro;

                await animalRepository.UpdateAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemocaAsync(Int64 Id)
        {
            try
            {
                AnimalModel model = await animalRepository.GetObjectAsync(Id);
                await animalRepository.RemoveAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
