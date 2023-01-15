using granado_clinica_veterinaria_utilitario.DataAnnotationValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace granado_clinica_veterinaria_business.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Nome é Obrigatório")]
        public String Nome { get; set; }

        [CPFValidationAttribute(ErrorMessage = "CPF é invalido")]
        public String CPF { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

        public ICollection<AnimalViewModel> Animals { get; set; }
    }
}
