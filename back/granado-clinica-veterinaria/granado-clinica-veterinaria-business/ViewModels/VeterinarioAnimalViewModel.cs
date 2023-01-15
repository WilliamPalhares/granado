using System;
using System.Collections.Generic;
using System.Text;

namespace granado_clinica_veterinaria_business.ViewModels
{
    public class VeterinarioAnimalViewModel
    {
        public Int64 VeterinarioId { get; set; }
        public Int64 AnimalId { get; set; }

        public VeterinarioViewModel Veterinario { get; set; }
        public AnimalViewModel Animal { get; set; }
    }
}
