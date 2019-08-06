using DDD.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Não encontrou objeto. [Nullo]");
                    });

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Necessário informar o CPF.")
                .NotNull().WithMessage("Necessário informar o CPF.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Necessário informar a data nascimento.")
                .NotNull().WithMessage("Necessário informar a data nascimento.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Necessário informar o nome.")
                .NotNull().WithMessage("Necessário informar o nome");
        }
    }
}
