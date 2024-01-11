using Posts.Challenge.Domain.Enums.User;
using Posts.Challenge.Domain.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Challenge.Application.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Favor informar um endereço de email válido");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Favor informar o nome completo");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Favor informar o telefone");

            RuleFor(p => p.Type)
                .IsEnumName(typeof(UserTypeEnum), caseSensitive: false)
                .WithMessage("Favor informar um tipo de usúario válido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Favor inserir a senha");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("confirmação de senha deve ser igual a senha informada");
        }
    }
}
