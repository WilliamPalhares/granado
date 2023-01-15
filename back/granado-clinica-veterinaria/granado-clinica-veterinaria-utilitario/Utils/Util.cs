using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace granado_clinica_veterinaria_utilitario.Utils
{
    public class Util
    {
        public String GetEnunDescription(Enum value)
        {
            FieldInfo field;
            try
            {
                field = value.GetType().GetField(value.ToString());

                if (field.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
                {
                    return attributes.First().Description;
                }

                return value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception ($"Erro: {ex.Message}", ex);
            }
        }

    }
}
