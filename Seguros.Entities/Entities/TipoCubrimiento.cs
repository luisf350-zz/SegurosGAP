using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seguros.Entities.Entities
{
    public class TipoCubrimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        [Range(1, 100, ErrorMessage = "La cobertura debe ser entre 1 y 100")]
        public double Cobertura { get; set; }

        public string NombreMostrar => $"{Nombre} - {Cobertura} %";
    }
}