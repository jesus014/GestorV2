using FluentValidation;
using GestorCyF.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Validadores
{
    public class ProveedoresValidator : GenericValidator<Proveedores>
    {
        public ProveedoresValidator()
        {
            RuleFor(e => e.empresa).NotNull().NotEmpty().Length(3, 300);
            RuleFor(e => e.folio_proveedor).NotNull().NotEmpty().Length(1, 300);
            RuleFor(e => e.email).NotNull().NotEmpty().Length(3, 300);
            RuleFor(e => e.telefono1).NotNull().NotEmpty().Length(10);
            RuleFor(e => e.telefono2).NotNull().NotEmpty().Length(10);

        }
    }
}
