using APIFoursquare.Application.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFoursquare.Services.Interface
{
    public interface IFoursquareService
    {
        Task<List<LugarView>> BuscarLugares(int categoria, decimal latitud, decimal longitud);
    }
}
