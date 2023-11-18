using APIFoursquare.Application.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFoursquare.Services.Interface
{
    public interface ICategoriaService
    {
        /// <summary>
        /// Obtener la lista de las categorías
        /// </summary>
        /// <returns></returns>
        Task<List<CategoriaView>> ObtenerListaAsync();
    }
}
