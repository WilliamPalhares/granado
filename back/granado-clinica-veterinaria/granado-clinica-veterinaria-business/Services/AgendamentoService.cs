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
    public class AgendamentoService
    {
        protected readonly IAgendamentoRepository agendamentoRepository;
        protected readonly IMapper mapper;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository, IMapper mapper)
        {
            this.agendamentoRepository = agendamentoRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AgendamentoViewModel>> GetListAtendimentoAsync()
        {
            try
            {
                return mapper.Map<IEnumerable<AgendamentoViewModel>>(await agendamentoRepository.GetListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AgendamentoViewModel> GetAtendimentoAsync(Int64 Id)
        {
            try
            {
                return mapper.Map<AgendamentoViewModel>(await agendamentoRepository.GetObjectAsync(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertAsync(AgendamentoViewModel viewModel)
        {
            try
            {
                AgendamentoModel model = mapper.Map<AgendamentoModel>(viewModel);
                model.DataCadastro = DateTime.Now;

                await agendamentoRepository.InsertAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(AgendamentoViewModel viewModel)
        {
            try
            {
                AgendamentoModel modelMapper = mapper.Map<AgendamentoModel>(viewModel);

                AgendamentoModel model = await agendamentoRepository.GetObjectAsync(viewModel.Id);
                model.DataCadastro = modelMapper.DataCadastro;

                await agendamentoRepository.UpdateAsync(model);
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
                AgendamentoModel model = await agendamentoRepository.GetObjectAsync(Id);
                await agendamentoRepository.RemoveAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
