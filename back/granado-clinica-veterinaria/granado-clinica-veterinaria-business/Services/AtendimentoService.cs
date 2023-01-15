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
    public class AtendimentoService
    {
        protected readonly IAtendimentoRepository atendimentoRepository;
        protected readonly IMapper mapper;

        public AtendimentoService(IAtendimentoRepository atendimentoRepository, IMapper mapper)
        {
            this.atendimentoRepository = atendimentoRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AtendimentoViewModel>> GetListAtendimentoAsync()
        {
            try
            {
                return mapper.Map<IEnumerable<AtendimentoViewModel>>(await atendimentoRepository.GetListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AtendimentoViewModel> GetAtendimentoAsync(Int64 Id)
        {
            try
            {
                return mapper.Map<AtendimentoViewModel>(await atendimentoRepository.GetObjectAsync(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertAsync(AtendimentoViewModel viewModel)
        {
            try
            {
                AtendimentoModel model = mapper.Map<AtendimentoModel>(viewModel);
                model.DataCadastro = DateTime.Now;

                await atendimentoRepository.InsertAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(AtendimentoViewModel viewModel)
        {
            try
            {
                AtendimentoModel modelMapper = mapper.Map<AtendimentoModel>(viewModel);

                AtendimentoModel model = await atendimentoRepository.GetObjectAsync(viewModel.Id);
                model.DataCadastro = modelMapper.DataCadastro;

                await atendimentoRepository.UpdateAsync(model);
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
                AtendimentoModel model = await atendimentoRepository.GetObjectAsync(Id);
                await atendimentoRepository.RemoveAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
