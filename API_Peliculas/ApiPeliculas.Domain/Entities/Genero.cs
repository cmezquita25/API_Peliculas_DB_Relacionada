using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPeliculas.Domain.Entities
{
    public partial class Genero
    {
        public int IdGenero { get; set; }
        public string Genero1 { get; set; }
        public int IdPelicula { get; set; }

        public virtual Pelicula Pelicula { get; set; }
    }
}
