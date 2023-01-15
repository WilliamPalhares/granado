using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace granado_clinica_veterinaria_domain.Models
{
    [Table("Agendamento")]
    public class AgendamentoModel : BaseModel
    {
        [Column("DataConsulta")]
        [Required(ErrorMessage = "")]
        public DateTime DataConsulta { get; set; }

        [Column("DataCadastro")]
        [Required(ErrorMessage = "")]
        public DateTime DataCadastro { get; set; }

        [Column("AnimalId")]
        public Int64 AnimalId { get; set; }

        [Column("VeterinarioId")]
        public Int64 VeterinarioId { get; set; }

        public AnimalModel Animal { get; set; }

        public VeterinarioModel Veterinario { get; set; }

    }
}
