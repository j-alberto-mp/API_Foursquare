using APIFoursquare.Application.Models;
using APIFoursquare.Application.Views;
using APIFoursquare.Data;
using AutoMapper;

namespace APIFoursquare.Services.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            // BD > Vistas
            CreateMap<Categoria, CategoriaView>()
                .ForMember(q => q.CategoriaId, f => f.MapFrom(q => q.Id))
                .ForMember(q => q.NombreCategoria, f => f.MapFrom(q => q.Nombre));
            CreateMap<Lugar, LugarFavoritoView>()
                .ForMember(q => q.IdLugar, f => f.MapFrom(q => q.Id));

            // Vistas > BD
            CreateMap<LugarModel, Lugar>()
                .ForMember(q => q.Id, f => f.MapFrom(q => q.IdLugar))
                .ForMember(q => q.CategoriaId, f => f.MapFrom(q => q.IdCategoria));
        }
    }
}