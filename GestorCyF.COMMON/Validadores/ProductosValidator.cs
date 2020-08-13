using FluentValidation;
using GestorCyF.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Validadores
{
    public class ProductosValidator : GenericValidator<Productos>
    {
        public ProductosValidator()
        {
            RuleFor(e => e.nombre).NotNull().NotEmpty().Length(3, 300);
            RuleFor(e => e.descripcion).NotNull().NotEmpty().Length(3, 300);
            RuleFor(e => e.folio_producto).NotNull().NotEmpty().Length(1, 300);
            RuleFor(e => e.marca).NotNull().Length(3,300);
            RuleFor(e => e.precio).NotNull();
            RuleFor(e => e.stock_actual).NotNull();
            RuleFor(e => e.stock_minimo).NotNull();
        }
    }
}
