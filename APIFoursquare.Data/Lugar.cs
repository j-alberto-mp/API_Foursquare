using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFoursquare.Data
{
    [Table("Lugares", Schema = "dbo")]
    public class Lugar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public int CategoriaId { get; set; }  
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Puntuacion { get; set; }
        [Required]
        [Column(TypeName = "decimal(9, 6)")]
        public decimal Latitud { get; set; }
        [Required]
        [Column(TypeName = "decimal(9, 6)")]
        public decimal Longitud { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}