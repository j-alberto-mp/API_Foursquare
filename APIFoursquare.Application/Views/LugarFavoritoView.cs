namespace APIFoursquare.Application.Views
{
    public class CategoriaLugarView
    {
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public List<LugarFavoritoView> Favoritos { get; set; }
    }

    public class LugarFavoritoView
    {
        public string IdLugar { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public decimal Puntuacion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public List<Fotos> FotosLugar { get; set; }
    }
}
