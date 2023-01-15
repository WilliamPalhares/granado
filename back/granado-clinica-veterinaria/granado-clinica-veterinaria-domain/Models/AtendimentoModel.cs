using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace granado_clinica_veterinaria_domain.Models
{
    [Table("Atendimento")]
    public class AtendimentoModel : BaseModel
    {
        [Column("Diagnostico")]
        [Required(ErrorMessage = "")]
        public String Diagnostico { get; set; }

        [Column("DataAtendimento")]
        [Required(ErrorMessage = "")]
        public DateTime DataAtendimento { get; set; }

        [Column("DataCadastro")]
        [Required(ErrorMessage = "")]
        public DateTime DataCadastro { get; set; }

        [Column("VeterinarioId")]
        public Int64 VeterinarioId { get; set; }

        [Column("AnimalId")]
        public Int64 AnimalId { get; set; }

        public VeterinarioModel Veterinario { get; set; }

        public AnimalModel Animal { get; set; }
    }
}
