using FluentValidation;
using GestorCyF.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Validadores
{
    public class VentasValidator : GenericValidator<Ventas>
    {
        public VentasValidator()
        {
            RuleFor(e => e.ElementosLista).NotNull();
            RuleFor(e => e.totalVenta).NotNull().NotEmpty();
            RuleFor(e => e.ElementosLista).NotNull().NotEmpty();
            RuleFor(e => e.fechaVenta).NotNull();
            RuleFor(e => e.cliente).NotNull();
        }
    }
}
