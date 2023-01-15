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
    public class ClienteService
    {
        protected readonly IClienteRepository clienteRepository;
        protected readonly AnimalService animalService;
        protected readonly IMapper mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper, AnimalService animalService)
        {
            this.clienteRepository = clienteRepository;
            this.animalService = animalService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ClienteViewModel>> GetListClienteAsync()
        {
            try
            {
                return mapper.Map<IEnumerable<ClienteViewModel>>(await clienteRepository.GetListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteViewModel> GetClienteAsync(Int64 Id)
        {
            try
            {
                return mapper.Map<ClienteViewModel>(await clienteRepository.GetObjectAsync(Id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertAsync(ClienteViewModel viewModel)
        {
            try
            {
                ClienteModel model = mapper.Map<ClienteModel>(viewModel);
                model.DataCadastro = DateTime.Now;

                model.Id = await clienteRepository.InsertAsync(model);

                if (model.Animals.Count > 0)
                {
                    foreach (var item in model.Animals)
                    {
                        item.Cliente = model;
                        item.ClienteId = model.Id;
                        await animalService.InsertAsync(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(ClienteViewModel viewModel)
        {
            try
            {
                ClienteModel modelMapper = mapper.Map<ClienteModel>(viewModel);

                ClienteModel model = await clienteRepository.GetObjectAsync(viewModel.Id);
                model.Nome = modelMapper.Nome;
                model.DataCadastro = modelMapper.DataCadastro;

                await clienteRepository.UpdateAsync(model);
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
                ClienteModel model = await clienteRepository.GetObjectAsync(Id);
                await clienteRepository.RemoveAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
