//#cSpell:disable

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiPeliculas.Domain.Entities;

namespace ApiPeliculas.Domain.Interfaces
{
    public interface IPelisRepository
    {
        Task<IQueryable<Pelicula>> AllMovies();
        Task<Pelicula> GetByID(int id);
        Task<int> CreateMovie(Pelicula movie);
        Task<bool> UpdateMovie(int id, Pelicula movie);

        //Task<bool> DeleteMovie(int id, Pelicula movie);
        

    }
}