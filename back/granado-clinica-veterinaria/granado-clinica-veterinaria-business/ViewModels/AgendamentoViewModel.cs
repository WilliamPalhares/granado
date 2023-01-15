using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace granado_clinica_veterinaria_business.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public DateTime DataConsulta { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

        public Int64 AnimalId { get; set; }
        public Int64 VeterinarioId { get; set; }
        public AnimalViewModel Animal { get; set; }
        public VeterinarioViewModel Veterinario { get; set; }
    }
}
