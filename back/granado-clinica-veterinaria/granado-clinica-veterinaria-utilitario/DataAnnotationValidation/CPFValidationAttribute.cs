using Caelum.Stella.CSharp.Validation;
using System.ComponentModel.DataAnnotations;

namespace granado_clinica_veterinaria_utilitario.DataAnnotationValidation
{
    public class CPFValidationAttribute : ValidationAttribute
    {
        public CPFValidationAttribute() {  }

        public override bool IsValid(object value)
        {
            return new CPFValidator().IsValid(value.ToString());
        }
    }
}
