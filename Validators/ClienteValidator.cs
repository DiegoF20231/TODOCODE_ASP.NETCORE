using BackendTodoCode.Models;
using FluentValidation;

namespace BackendTodoCode.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.NombreCliente).NotNull().WithMessage("Ingrese nombre")
            .NotEmpty().WithMessage("Ingrese nombre");

            RuleFor(c => c.EmailCliente).NotNull().WithMessage("Ingrese correo")
            .NotEmpty().WithMessage("Ingrese correo")
            .EmailAddress().WithMessage("Ingrese un correo valido");

            RuleFor(c => c.CelularCliente).NotNull().WithMessage("Ingrese celular")
            .NotEmpty().WithMessage("Ingrese celular");

            RuleFor(c => c.ApellidoCliente).NotNull().WithMessage("Ingrese apellido")
            .NotEmpty().WithMessage("Ingrese apellido");

            RuleFor(c => c.Dniempleado).NotNull().WithMessage("Ingrese Dni")
            .NotEmpty().WithMessage("Ingrese Dni");

            RuleFor(c => c.DireccionCliente).NotNull().WithMessage("Ingrese Direccion")
            .NotEmpty().WithMessage("Ingrese Direccion");

            RuleFor(c => c.FechaNacimiento).NotNull().WithMessage("Ingrese Fecha")
            .NotEmpty().WithMessage("Ingrese Fecha");

            RuleFor(c => c.IdNacionalidad).NotNull().WithMessage("Ingrese IdNacionalidad")
            .NotEmpty().WithMessage("Ingrese IdNacionalidad");




        }

        private bool IsNumber(string numero)
        {
            return decimal.TryParse(numero, out _);
        }


    }
}
