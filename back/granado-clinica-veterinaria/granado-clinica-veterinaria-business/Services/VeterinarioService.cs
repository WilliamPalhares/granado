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
    public class VeterinarioService
    {
        protected readonly IVeterinarioRepository veterinarioRepository;
        protected readonly IMapper mapper;

        public VeterinarioService(IVeterinarioRepository veterinarioRepository, IMapper mapper)
        {
            this.veterinarioRepository = veterinarioRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<VeterinarioViewModel>> GetListVeterinarioAsync()
        {
            try
            {
                return mapper.Map<IEnumerable<VeterinarioViewModel>>(await veterinarioRepository.GetListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<VeterinarioViewModel> GetVeterinarioAsync(Int64 Id)
        {
            try
            {
                return mapper.Map<VeterinarioViewModel>(await veterinarioRepository.GetObjectAsync(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertAsync(VeterinarioViewModel viewModel)
        {
            try
            {
                VeterinarioModel model = mapper.Map<VeterinarioModel>(viewModel);
                model.DataCadastro = DateTime.Now;

                await veterinarioRepository.InsertAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(VeterinarioViewModel viewModel)
        {
            try
            {
                VeterinarioModel modelMapper = mapper.Map<VeterinarioModel>(viewModel);

                VeterinarioModel model = await veterinarioRepository.GetObjectAsync(viewModel.Id);
                model.Nome = modelMapper.Nome;
                model.DataCadastro = modelMapper.DataCadastro;

                await veterinarioRepository.UpdateAsync(model);
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
                VeterinarioModel model = await veterinarioRepository.GetObjectAsync(Id);
                await veterinarioRepository.RemoveAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
