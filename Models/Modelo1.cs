using System.ComponentModel.DataAnnotations;

namespace Josmery_AP1_P1.Models
{
    public class Modelo1
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; } = String.Empty;
    }
}
