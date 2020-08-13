using FluentValidation;
using GestorCyF.COMMON.Entidades;

namespace GestorCyF.COMMON.Validadores
{
    public abstract class GenericValidator<T> : AbstractValidator<T> where T : BaseDTO
    {
        public GenericValidator()
        {
            //RuleFor(e => e.Id).NotNull().NotEmpty();    
            RuleFor(e => e.FechaHora).NotNull().NotEmpty();
        }
    }
}