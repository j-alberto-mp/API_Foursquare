using APIFoursquare.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFoursquare.Services.Interface
{
    public interface IFoursquareService
    {
        Task<List<LugarViewModel>> BuscarLugares(int categoria, decimal latitud, decimal longitud);
    }
}
