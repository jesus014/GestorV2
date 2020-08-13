using FluentValidation;
using GestorCyF.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Validadores
{
    public class ComprasValidator : GenericValidator<Compras>
    {
        public ComprasValidator()
        {
            RuleFor(e => e.cantidad).NotNull().NotEmpty();
            RuleFor(e => e.producto).NotNull();
            RuleFor(e => e.proveedor).NotNull();
            RuleFor(e => e.fechaCompra).NotNull().NotEmpty();
            RuleFor(e => e.precioCompra).NotNull().NotEmpty();
        }
    }
}
