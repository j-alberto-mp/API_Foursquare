using APIFoursquare.Application;
using APIFoursquare.Data;
using AutoMapper;

namespace APIFoursquare.Services.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>()
                .ForMember(q => q.CategoriaId, f => f.MapFrom(q => q.Id))
                .ForMember(q => q.NombreCategoria, f => f.MapFrom(q => q.Nombre));
        }
    }
}