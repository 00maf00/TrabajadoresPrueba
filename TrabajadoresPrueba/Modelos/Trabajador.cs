using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
    }
}
