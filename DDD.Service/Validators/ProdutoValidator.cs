using DDD.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Service.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(a => a)
                   .NotNull()
                   .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Não encontrou objeto. [Nullo]");
                    });
            RuleFor(a => a.Codigo)
                .NotNull()
                .WithMessage("Codigo não pode estar nullo");

            RuleFor(a => a.Fabricante)
                .NotNull()
                .WithMessage("Fabricante não pode estar nullo");

            RuleFor(a => a.Nome)
                .NotNull()
                .WithMessage("Nome não pode estar nullo");

            RuleFor(a => a.Preco)
                .NotNull()
                .WithMessage("Preço não pode ser nullo");
                
            RuleFor(a => a.Preco)
                .LessThanOrEqualTo(0)
                .WithMessage("Preço tem que ser maior que 0");
        }
    }
}
