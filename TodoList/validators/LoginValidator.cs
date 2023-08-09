using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entities.Models;

namespace TodoList.validators
{
    public class LoginValidator: AbstractValidator<LoginRequestModel>
    {
        public LoginValidator()
        {
            RuleFor(user => user.Username).NotNull().NotEmpty().MinimumLength(4).MaximumLength(20);
            RuleFor(user => user.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(20);
        }
    }
}
