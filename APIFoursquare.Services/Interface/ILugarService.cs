using APIFoursquare.Application.Models;
using APIFoursquare.Application.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFoursquare.Services.Interface
{
    public interface ILugarService
    {
        /// <summary>
        /// Guardar un nuevo lugar como favorito
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        Task<bool> GuardarAsync(LugarModel modelo);

        /// <summary>
        /// Obtener la lista de los lugares favoritos
        /// </summary>
        /// <returns></returns>
        Task<List<CategoriaLugarView>> ObtenerLugaresFavoritosAsync();
    }
}
