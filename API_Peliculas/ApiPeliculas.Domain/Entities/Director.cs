using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPeliculas.Domain.Entities
{
    public partial class Director
    {
        public int IdDirector { get; set; }
        public string Nombre { get; set; }
        public int IdPelicula { get; set; }

        public virtual Pelicula Pelicula{ get; set; }

        
    }
}
