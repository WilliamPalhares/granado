using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace granado_clinica_veterinaria_domain.Models
{
    [Table("VeterinarioAnimal")]
    public class VeterinarioAnimalModel : BaseModel
    {
        [Column("VeterinarioId")]
        public Int64 VeterinarioId { get; set; }

        [Column("AnimalId")]
        public Int64 AnimalId { get; set; }

        public VeterinarioModel Veterinario { get; set; }
        public AnimalModel Animal { get; set; }
    }
}
