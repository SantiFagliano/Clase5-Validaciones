using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Clase5_Validaciones.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Campo requerido")]
        public Especie Especie { get; set; }

        [Required(ErrorMessage = "*Campo requerido")]
        [CustomTexto(ErrorMessage = "*No debe ingresar caracteres espceiales")]
        public string Estado { get; set; }

        [Range(0, 5000, ErrorMessage = "*El peso debe estar entre 0 y 5000")]
        public int? Peso { get; set; }

        public string Color { get; set; }

        [StringLength(200, ErrorMessage = "*No se puede ingresar mas de 200 caracteres")]
        [CustomTexto(ErrorMessage = "*No debe ingresar caracteres espceiales")]
        public string Nombre { get; set; }

        [CustomTexto(ErrorMessage = "*No debe ingresar caracteres espceiales")]
        public string DatosDeContacto { get; set; }

        [EmailAddress(ErrorMessage = "*Ingrese un formato de email correcto")]
        public string EmailDeContacto { get; set; }

        public List<string> Fotos { get; set; }


        public Mascota()
        {
            Fotos = new List<string>();
        }
    }

}
public class CustomTexto : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        string regexItem = "^[a-zA-Z0-9 ]*$";
        string valor = (string)value;

        return Regex.IsMatch(valor, regexItem);
    }
}
