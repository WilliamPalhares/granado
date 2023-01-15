using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace granado_clinica_veterinaria_business.ViewModels
{
    public class VeterinarioViewModel : BaseViewModel
    {
        public String Nome { get; set; }

        public Boolean Geriatra { get; set; }

        public DateTime DataContratacao { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

        public ICollection<AgendamentoViewModel> Agendamentos { get; set; }

        public IList<VeterinarioAnimalViewModel> VeterinarioAnimals { get; set; }

        public ICollection<AtendimentoViewModel> Atendimentos { get; set; }
    }
}
