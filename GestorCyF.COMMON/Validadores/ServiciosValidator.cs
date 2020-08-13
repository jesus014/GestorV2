using FluentValidation;
using GestorCyF.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Validadores
{
    public class ServiciosValidator : GenericValidator<Servicios>
    {
        public ServiciosValidator()
        {
            RuleFor(e => e.nombre).NotNull().NotEmpty().Length(3, 300);
            RuleFor(e => e.folio_servicio).NotNull().NotEmpty().Length(1, 300);
            RuleFor(e => e.descripcion).NotNull().Length(3, 300);
            RuleFor(e => e.precio).NotNull();
             }
    }
}
