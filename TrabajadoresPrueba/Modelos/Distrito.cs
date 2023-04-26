using System.ComponentModel.DataAnnotations;

namespace TrabajadoresPrueba.Modelos
{
    public class Distrito
    {
        public int Id { get; set; }
        [Required]
        public string NombreDistrito { get; set; } = string.Empty;
        public int IdProvincia { get; set; }
    }
}
