//cSpell:disable

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using ApiPeliculas.Infrastructure.Data;
using ApiPeliculas.Domain.Entities;
using ApiPeliculas.Domain.Interfaces;

#pragma warning restore format

namespace ApiPeliculas.Infrastructure.Repositories
{
    public class MovieSqlRepository : IPelisRepository
    {
        private readonly PeliculasmezqContext _context;

        public MovieSqlRepository(PeliculasmezqContext context)
        {
            _context = context;
        }



        #region Peticiones GET
        public async Task<IQueryable<Pelicula>> AllMovies()
        {
            var movies = await _context.Peliculas.AsQueryable<Pelicula>().Include(x => x.Directors).Include(g => g.Generos).AsNoTracking().ToListAsync();
            return movies.AsQueryable();
        }

        public async Task<Pelicula> GetByID(int id)
        {
            var movies = await _context.Peliculas.Include(x => x.Generos).Include(d => d.Directors).FirstOrDefaultAsync(x => x.Id == id);
            return movies;
        }

        #endregion

        //Registrar una pelicula
        public async Task<int> CreateMovie(Pelicula movie)
        {
            var entity = movie;

            await _context.Peliculas.AddAsync(entity);

            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
            
                throw new Exception("¡ERROR!: No se pudo registrar la pelicula...Verifique su información.");
            
            
            return entity.Id;
        }

        //Actualizar pelicula

        public async Task<bool> UpdateMovie(int id, Pelicula movie)
        {
            if(id <= 0 || movie == null)
            {
                throw new ArgumentException("Falta informacion para poder realizar la modificacion");
            }
            var entity = await GetByID(id);

            entity.Titulo = movie.Titulo;
            entity.Puntuacion = movie.Puntuacion;
            entity.Rating = movie.Rating;
            entity.FechaPublicacion = movie.FechaPublicacion;

            if(movie.Generos!= null)
            {
                if(entity.Generos == null)
                    entity.Generos = new Genero();

                    entity.Generos.Genero1 = movie.Generos.Genero1;

            }
            else if(entity.Generos!= null) 
                _context.Remove(entity.Generos);
            
            if(movie.Directors!=null)
            {
                if(entity.Directors==null)
                    entity.Directors = new Director();

                    entity.Directors.Nombre = movie.Directors.Nombre;
            }
            else if(entity.Directors!=null)
                _context.Remove(entity.Directors);

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

                

    }
}