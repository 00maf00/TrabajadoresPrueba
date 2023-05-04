using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrabajadoresPrueba.Modelos
{
    public class Trabajador
    {
        public int Id { get; set; }
        [Required]
        public string TipoDocumento { get; set; } = string.Empty;
        [Required]
        public string NumeroDocumento { get; set; } = string.Empty;
        [Required]
        public string Nombres { get; set; } = string.Empty;
        [Required]
        public string Sexo { get; set; } = string.Empty;
        [DisplayName ("Departamento")]

        public int IdDepartamento { get; set; }
        [DisplayName("Provincia")]

        public int IdProvincia { get; set; }
        [DisplayName("Distrito")]
        public int IdDistrito { get; set; }

        public string? Ficha { get; set; } = string.Empty;

        public string? Foto { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile FichaIFormFile { get; set; }

        [NotMapped]
        public IFormFile FotoIFormFile { get; set; }

        public string FichaURL => Ficha == null ? "" : Ficha;

        public string FichaURL2
        {
            get
            {
                if (string.IsNullOrEmpty(Ficha))
                {
                    return "";
                }
                else
                {
                    return $"https://localhost:7067/{Ficha}";
                }
            }
        }

    }
}
