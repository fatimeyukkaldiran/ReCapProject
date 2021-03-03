using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    class UserValidator :AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.PasswordHash).NotEmpty();
           // RuleFor(u => u.PasswordSalt).MinimumLength(6);
            RuleFor(u => u.FirstName).NotEmpty();
        }
    }
}
