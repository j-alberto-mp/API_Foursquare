using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFoursquare.Data
{
    [Table("LugaresFavoritos", Schema = "dbo")]
    public class LugarFavorito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string LugarId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("LugarId")]
        public Lugar Lugar { get; set; }
    }
}