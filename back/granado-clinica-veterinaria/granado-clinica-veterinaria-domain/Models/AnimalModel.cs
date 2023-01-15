using granado_clinica_veterinaria_domain.Enuns;
using granado_clinica_veterinaria_utilitario.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace granado_clinica_veterinaria_domain.Models
{
    [Table("Animal")]
    public class AnimalModel : BaseModel
    {
        [Column("Nome")]
        [Required(ErrorMessage = "")]
        public String Nome { get; set; }

        [Column("Idade")]
        [Required(ErrorMessage = "")]
        public Int32 Idade { get; set; }

        [Column("DataCadastro")]
        [Required(ErrorMessage = "")]
        public DateTime DataCadastro { get; set; }

        [Column("ClienteId")]
        public Int64 ClienteId { get; set; }

        [Column("TipoAnimalId")]
        public Int64 TipoAnimalId { get; set; }

        public ClienteModel Cliente { get; set; }

        public TipoAnimalModel TipoAnimal { get; set; }

        public ICollection<AgendamentoModel> Agendamentos { get; set; }

        public IList<VeterinarioAnimalModel> VeterinarioAnimals { get; set; }

        public ICollection<AtendimentoModel> Atendimentos { get; set; }

        public Boolean AnimalIdoso()
        {
            Boolean idoso = false;
            Util util = new Util();

            try
            {
                if ((util.GetEnunDescription(TipoAnimalEnum.GATO) == this.TipoAnimal.Nome) 
                    || (util.GetEnunDescription(TipoAnimalEnum.CACHORRO) == this.TipoAnimal.Nome))
                {
                    if (this.Idade >= 7)
                    {
                        idoso = true;
                    }
                }
                else if (util.GetEnunDescription(TipoAnimalEnum.HAMSTERS) == this.TipoAnimal.Nome)
                {
                    if (this.Idade >= 2)
                    {
                        idoso = true;
                    }
                }
                else
                {
                    throw new Exception("Tipo de animal informado invalido");
                }

                return idoso;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: { ex.Message }", ex);
            }
        }
    }
}
