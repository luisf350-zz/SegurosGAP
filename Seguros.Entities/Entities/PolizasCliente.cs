using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seguros.Entities.Entities
{
    public class PolizasCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Poliza")]
        public int PolizaId { get; set; }

        [Display(Name = "Inicio Cubrimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InicioCubrimiento { get; set; }

        public bool Activa { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Poliza Poliza { get; set; }

        public string EsActiva => Activa ? "Si" : "No";
    }
}