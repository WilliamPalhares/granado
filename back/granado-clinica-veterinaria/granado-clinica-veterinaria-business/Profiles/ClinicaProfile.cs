using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using granado_clinica_veterinaria_business.ViewModels;
using granado_clinica_veterinaria_domain.Models;

namespace granado_clinica_veterinaria_business.Profiles
{
    public  class ClinicaProfile : Profile
    {
        public ClinicaProfile()
        {
            CreateMap<AgendamentoModel, AgendamentoViewModel>();
            CreateMap<AgendamentoViewModel, AgendamentoModel>().ForMember(op => op.Id, opt => opt.Ignore());

            CreateMap<AnimalModel, AnimalViewModel>();
            CreateMap<AnimalViewModel, AnimalModel>().ForMember(op => op.Id, opt => opt.Ignore());

            CreateMap<AtendimentoModel, AtendimentoViewModel>();
            CreateMap<AtendimentoViewModel, AtendimentoModel>().ForMember(op => op.Id, opt => opt.Ignore());

            CreateMap<ClienteModel, ClienteViewModel>();
            CreateMap<ClienteViewModel, ClienteModel>().ForMember(op => op.Id, opt => opt.Ignore());

            CreateMap<TipoAnimalModel, TipoAnimalViewModel>();
            CreateMap<TipoAnimalViewModel, TipoAnimalModel>().ForMember(op => op.Id, opt => opt.Ignore());

            CreateMap<VeterinarioModel, VeterinarioViewModel>();
            CreateMap<VeterinarioViewModel, VeterinarioModel>().ForMember(op => op.Id, opt => opt.Ignore());
        }
    }
}
