using FluentValidation;
using Posts.Challenge.Domain.Requests.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.Challenge.Application.Validators
{
    public class PostRequestValidator : AbstractValidator<PostRequest>
    {
        public PostRequestValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Favor informar o conteúdo do post");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Favor informar o título do post");
        }
    }
}
