
using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
    public class Facultades
    {
        [Key]
        public int facultad_id { get; set; }
        public string? nombre_facultad { get; set; }
        public char? estado { get; set; }
    }
}
