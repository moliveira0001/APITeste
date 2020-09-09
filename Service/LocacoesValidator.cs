using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
  public  class LocacoesValidator : AbstractValidator<Locacoes>
    {
        public LocacoesValidator()
        {
            RuleFor(c => c.CodCliente)
                    .NotNull()
                    .NotEmpty()
                    .OnAnyFailure(x =>
                    {
                        x.MensagemErroValidator.Add("Código do cliente obrigatorio!");
                        x.BadRequest = true;
                    });

            RuleFor(c => c.CodFilme)
                   .NotNull()
                   .NotEmpty()
                   .OnAnyFailure(x =>
                   {
                       x.MensagemErroValidator.Add("Código do filme obrigatorio!");
                       x.BadRequest = true;
                   });
        }

    }
}
