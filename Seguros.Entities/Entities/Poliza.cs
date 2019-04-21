using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seguros.Entities.Entities
{
    public class Poliza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(500)]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo Cubrimiento")]
        public int TipoCubrimientoId { get; set; }

        [Display(Name = "Tipo Riesgo")]
        public int TipoRiesgoId { get; set; }

        [Display(Name = "Meses Cobertura")]
        public int MesesCobertura { get; set; }

        [Display(Name = "Precio Poliza")]
        public decimal Precio { get; set; }

        public TipoCubrimiento Cubrimiento { get; set; }

        public TipoRiesgo Riesgo { get; set; }
    }
}