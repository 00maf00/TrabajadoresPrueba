﻿using System.ComponentModel.DataAnnotations;

namespace TrabajadoresPrueba.Modelos
{
    public class Provincia
    {
        public int Id { get; set; }
        [Required]
        public string NombreProvincia {  get; set; } = string.Empty;
        public int IdDepartamento { get; set; }
    }
}
