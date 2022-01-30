//#cSpell:disable

using ApiPeliculas.Domain.Dtos.Request;
using FluentValidation;

namespace ApiPeliculas.Infrastructure.Validators
{
    public class MoviesValidator : AbstractValidator<PelisRequestMapper>
    {
        public MoviesValidator()
        {
            RuleFor(p => p.Titulo).NotNull().NotEmpty().Length(2,500);
            RuleFor(p => p.Nombre).NotNull().NotEmpty().Length(5,300);
            RuleFor(p => p.Genero1).NotNull().NotEmpty().Length(3,80);
            RuleFor(p => p.Puntuacion).NotNull().NotEmpty();
            RuleFor(p => p.Rating).NotNull().NotEmpty();
            RuleFor(p => p.FechaPublicacion).NotNull().NotEmpty().Length(4);
        }
    }
}