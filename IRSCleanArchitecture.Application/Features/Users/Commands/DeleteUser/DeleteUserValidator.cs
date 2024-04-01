using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
