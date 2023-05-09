using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrabajadoresPrueba.Modelos
{
    public class Trabajador
    {
        public int Id { get; set; }
        [DisplayName("Tipo Documento")]

        public string TipoDocumento { get; set; } = string.Empty;
        [DisplayName("Número Documento")]

        public string NumeroDocumento { get; set; } = string.Empty;
        [DisplayName("Nombres")]

        public string Nombres { get; set; } = string.Empty;
        [DisplayName("Sexo")]

        public string Sexo { get; set; } = string.Empty;
        [DisplayName ("Departamento")]

        public int IdDepartamento { get; set; }
        [DisplayName("Provincia")]

        public int IdProvincia { get; set; }
        [DisplayName("Distrito")]
        public int IdDistrito { get; set; }

        //nombre de los archivos
        public string? Ficha { get; set; } 

        public string? Foto { get; set; } 
        [NotMapped]
        public IFormFile FichaIFormFile { get; set; } // bits 

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

        public string FotoURL => Foto == null ? "" : Foto;
        public string FotoURL2
        {
            get 
            {
                if (string.IsNullOrEmpty(Foto))
                {
                    return "";
                }
                else
                {
                    return $"https://localhost:7067/{Foto}";
                }
            }
        }
    }
}
