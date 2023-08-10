using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entities.Models;

namespace TodoList.validators
{
    public class TodoValidator : AbstractValidator<TodoModel>
    {
        public TodoValidator()
        {
            RuleFor(todo => todo.Title).NotNull().NotEmpty().MinimumLength(4).MaximumLength(50);
            RuleFor(todo => todo.Description).NotNull().NotEmpty().MinimumLength(4).MaximumLength(200);
            
        }
    }
}
