using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace granado_clinica_veterinaria_domain.Enuns
{
    public enum TipoAnimalEnum
    {
        [Description("GATO")]
        GATO = 1,

        [Description("CACHORRO")]
        CACHORRO = 2,

        [Description("HAMSTERS")]
        HAMSTERS = 3
    }
}
