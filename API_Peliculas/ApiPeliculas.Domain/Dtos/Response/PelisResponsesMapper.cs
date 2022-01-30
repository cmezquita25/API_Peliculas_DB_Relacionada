//cSpell:disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Domain.Dtos.Response
{
    public class PelisResponsesMapper
    {
        public int Id {get; set;}
        public string Titulo {get; set;}
        public string Genero {get; set;}
        public string Director {get; set;}
        public string Critica{get;set;}
        public string Año_De_Estreno { get; set; }
    }
}