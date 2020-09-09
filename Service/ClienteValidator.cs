using Domain;
using FluentValidation;

namespace Service
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Endereco)
                    .NotNull()
                    .NotEmpty()
                    .OnAnyFailure(x =>
                    {
                        x.MensagemErroValidator.Add("Endereço não cadastrado!");
                        x.BadRequest = true;
                    });

            RuleFor(c => c.CPF)
                   .NotNull()
                   .NotEmpty()
                   .OnAnyFailure(x =>
                   {
                       x.MensagemErroValidator.Add("CPF Obrigatório!");
                       x.BadRequest = true;
                   });


            RuleFor(c => c.Nome)
                   .NotNull()
                   .NotEmpty()
                   .OnAnyFailure(x =>
                   {
                       x.MensagemErroValidator.Add("Nome não cadastrado!");
                       x.BadRequest = true;
                   });

            RuleFor(c => c.Telefone)
                   .NotNull()
                   .NotEmpty()
                   .OnAnyFailure(x =>
                   {
                       x.MensagemErroValidator.Add("Telefone não cadastrado!");
                       x.BadRequest = true;
                   });
        }
    }
}
