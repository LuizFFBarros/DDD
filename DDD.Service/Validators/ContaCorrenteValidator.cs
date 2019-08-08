using DDD.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Service.Validators
{
    public class ContaCorrenteValidator: AbstractValidator<ContaCorrente>
    {
        public ContaCorrenteValidator()
        {
            RuleFor(a => a)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentException("Não encontrou objeto [null]");
                });

            RuleFor(a => a.CPF)
                .NotNull()
                .WithMessage("CPF não pode ser nullo");

            RuleFor(a => a.LimiteCredito)
                .NotNull()
                .WithMessage("Limite Credito não pode ser nullo");

            RuleFor(a => a.Saldo)
                .NotNull()
                .WithMessage("Saldo não pode ser nullo");

            RuleFor(a => a.SaldoLimiteCredito)
                .NotNull()
                .WithMessage("Saldo Limite Credito não pode ser nullo");

            RuleFor(a => a.Telefone)
                .NotNull()
                .WithMessage("Telefone não pode ser nullo");
        }
    }
}
