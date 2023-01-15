using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace granado_clinica_veterinaria_business.ViewModels
{
    public class AtendimentoViewModel : BaseViewModel
    {
        public String Diagnostico { get; set; }
        public DateTime DataAtendimento { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }
        
        public Int64 VeterinarioId { get; set; }
        public Int64 AnimalId { get; set; }

        public VeterinarioViewModel Veterinario { get; set; }
        public AnimalViewModel Animal { get; set; }
    }
}
