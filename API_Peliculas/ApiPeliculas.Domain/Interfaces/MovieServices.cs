//cSpell:disable

using ApiPeliculas.Domain.Entities;

namespace ApiPeliculas.Domain.Interfaces
{
    public interface MovieServices
    {
        bool PeliValidated(Pelicula movie);
        bool UpdateMovie_Validated(Pelicula movie);
    }
}