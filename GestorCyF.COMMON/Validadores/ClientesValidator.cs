using FluentValidation;
using GestorCyF.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Validadores
{
    public class ClientesValidator : GenericValidator<Clientes>
    {
        public ClientesValidator()
        {
            RuleFor(e => e.nombre).NotNull().NotEmpty().Length(3, 300);
            RuleFor(e => e.apellidop).NotNull().NotEmpty().Length(3, 300);
            RuleFor(e => e.apellidom).NotNull().NotEmpty().Length(3, 300);
            RuleFor(e => e.telefono).NotNull().NotEmpty().Length(10);
            RuleFor(e => e.email).NotNull().NotEmpty().Length(3, 300).EmailAddress();
        }
    }
}
