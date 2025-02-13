using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.Entity
{
    public class ProyectoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Required]
        public int IdAlumno { get; set; }
        
        [Required]
        public int IdProfesor { get; set; }

        [Required]
        [MaxLength(50)]
        public String Estado { get; set; }

    }
}
