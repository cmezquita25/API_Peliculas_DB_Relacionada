//cSpell:disable

using AutoMapper;
using ApiPeliculas.Domain.Entities;
using ApiPeliculas.Domain.Dtos.Request;
using ApiPeliculas.Domain.Dtos.Response;

namespace ApiPeliculas.Application.Mapping
{
    public class MoviesMapper : Profile
    {
        public MoviesMapper()
        {
            CreateMap<Pelicula, PelisResponsesMapper>()

            .ForMember(mv => mv.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(mv => mv.Director, opt => opt.MapFrom(src => src.Directors == null ? "N/A" : src.Directors.Nombre))
            .ForMember(mv => mv.Genero, opt => opt.MapFrom(src => src.Generos == null ? "N/A" : src.Generos.Genero1))
            .ForMember(mv => mv.Critica, opt => opt.MapFrom(src => $"Puntuacion: {src.Puntuacion} estrellas,  Rating:  {src.Rating}%"))
            .ForMember(mv => mv.Año_De_Estreno, opt => opt.MapFrom(src => src.FechaPublicacion));

            CreateMap<PelisRequestMapper, Pelicula>()
            //.ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
            .ForPath(dest => dest.Generos.Genero1, opt => opt.MapFrom(src => src.Genero1))
            .ForPath(dest => dest.Directors.Nombre, opt => opt.MapFrom(src => src.Nombre));

        }
    }
}