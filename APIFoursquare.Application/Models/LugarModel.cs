namespace APIFoursquare.Application.Models
{
    public class LugarModel
    {
        public string IdLugar { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public decimal Puntuacion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
    }
}
