using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entities.Models;

namespace TodoList.validators
{
    public class SignUpValidator: AbstractValidator<UserAuthModel>
    {
        public SignUpValidator()
        {
            RuleFor(user => user.Username).NotNull().NotEmpty().MinimumLength(4).MaximumLength(20);
            RuleFor(user => user.Email).EmailAddress();
            RuleFor(user => user.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(20);
        }
    }
}
