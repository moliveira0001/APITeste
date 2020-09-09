using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
   public class FilmeValidator : AbstractValidator<Filme>
    {
        public FilmeValidator()
        {
            RuleFor(c => c.NomeFilme)
                   .NotNull()
                   .NotEmpty()
                   .OnAnyFailure(x =>
                   {
                       x.MensagemErroValidator.Add("Nome do filme obrigatorio!");
                       x.BadRequest = true;
                   });

        }
    }
}
