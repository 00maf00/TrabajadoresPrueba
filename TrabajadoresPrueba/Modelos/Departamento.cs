using System.ComponentModel.DataAnnotations;

namespace TrabajadoresPrueba.Modelos
{
    public class Departamento
    {
        public int Id { get; set; }
        [Required]
        public string NombreDepartamento { get; set;} = string.Empty; //string.Empty es para que el registro sea obligatorio
    }
}
