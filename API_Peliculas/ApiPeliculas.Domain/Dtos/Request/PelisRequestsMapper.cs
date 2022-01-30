//cSpell:disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Domain.Dtos.Request
{
    public class PelisRequestMapper
    {
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Genero1 { get; set; }
        public int Puntuacion { get; set; }
        public decimal Rating { get; set; }
        public string FechaPublicacion { get; set; }
    }
}