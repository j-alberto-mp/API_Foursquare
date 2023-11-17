using APIFoursquare.Data;
using Microsoft.EntityFrameworkCore;

namespace APIFoursquare.Repository.Context
{
    public class ApiFoursquareDbContext : DbContext
    {
        public ApiFoursquareDbContext(DbContextOptions<ApiFoursquareDbContext> options) : base(options) { }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Lugar> Lugares { get; set; }
        public virtual DbSet<LugarFavorito> LugaresFavoritos { get; set; }
    }
}