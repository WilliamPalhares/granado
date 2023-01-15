using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace granado_clinica_veterinaria_domain.Models
{
    [Table("Veterinario")]
    public class VeterinarioModel : BaseModel
    {
        [Column("Nome")]
        [Required(ErrorMessage = "")]
        public String Nome { get; set; }

        [Column("Geriatra")]
        [Required(ErrorMessage = "")]
        public Boolean Geriatra { get; set; }

        [Column("DataContratacao")]
        [Required(ErrorMessage = "")]
        public DateTime DataContratacao { get; set; }

        [Column("DataCadastro")]
        [Required(ErrorMessage = "")]
        public DateTime DataCadastro { get; set; }

        public ICollection<AgendamentoModel> Agendamentos { get; set; }

        public IList<VeterinarioAnimalModel> VeterinarioAnimals { get; set; }

        public ICollection<AtendimentoModel> Atendimentos { get; set; }
    }
}
