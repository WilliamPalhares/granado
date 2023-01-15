using granado_clinica_veterinaria_domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace granado_clinica_veterinaria_business.ViewModels
{
    public class TipoAnimalViewModel : BaseViewModel
    {
        public String Nome { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
