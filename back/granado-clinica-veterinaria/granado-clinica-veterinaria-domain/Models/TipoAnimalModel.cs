using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace granado_clinica_veterinaria_domain.Models
{
    [Table("TipoAnimal")]
    public class TipoAnimalModel : BaseModel
    {
        [Column("Nome")]
        [Required(ErrorMessage = "")]
        public String Nome { get; set; }

        [Column("DataCadastro")]
        [Required(ErrorMessage = "")]
        public DateTime DataCadastro { get; set; }

        public ICollection<AnimalModel> Animals { get; set; }
    }
}
