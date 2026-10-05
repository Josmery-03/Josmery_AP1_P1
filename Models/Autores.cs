using System.ComponentModel.DataAnnotations;

namespace Josmery_AP1_P1.Models
{
    public class Autores
    {
        [Key]
        public int IdAutores{ get; set; }

        [Required(ErrorMessage = "El nombre deber ser obligatorio")]
        public String Nombres { get; set; } = String.Empty;

        [Required(ErrorMessage = "La nacionalidad es obligatoria")]
        public String Nacionalidad { get; set; } = String.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        [Range(0.01, double.MaxValue, ErrorMessage = "El sueldo debe ser mayor a 0")]
        public decimal Sueldo { get; set; }
    }
}
