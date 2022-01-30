//cSpell:disable

using ApiPeliculas.Domain.Entities;
using ApiPeliculas.Domain.Interfaces;

namespace ApiPeliculas.Application.Services
{
    public class ServicesMovie : MovieServices
    {
        public bool PeliValidated(Pelicula movie)
        {
            if(string.IsNullOrEmpty(movie.Titulo))
                return false;

            if(movie.Id <= 0)
                return false;

            if(string.IsNullOrEmpty(movie.FechaPublicacion))
                return false;

            return true;
        }
        public bool UpdateMovie_Validated (Pelicula movie)
        {
            if(string.IsNullOrEmpty(movie.Titulo))
                return false;

            if(movie.Id<=0)
                return false;

            if(string.IsNullOrEmpty(movie.FechaPublicacion))
                return false;

            return true;
        }

    
    }
}