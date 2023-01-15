using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace granado_clinica_veterinaria_business.ViewModels
{
    public class AnimalViewModel : BaseViewModel
    {
        public String Nome { get; set; }

        public Int32 Idade { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

        public Int64 ClienteId { get; set; }

        public Int64 TipoAnimalId { get; set; }

        public ClienteViewModel Cliente { get; set; }

        public TipoAnimalViewModel TipoAnimal { get; set; }

        public ICollection<AgendamentoViewModel> Agendamentos { get; set; }

        public ICollection<AtendimentoViewModel> Atendimentos { get; set; }
    }
}
