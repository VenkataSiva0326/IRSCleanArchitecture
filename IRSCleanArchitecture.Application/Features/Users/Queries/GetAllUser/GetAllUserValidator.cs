using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace IRSCleanArchitecture.Application.Features.Users.Queries.GetAllUser
{
    public class GetAllUserValidator : AbstractValidator<GetAllUserResponse>
    {
        public GetAllUserValidator()
        {
            // sem validação
        }
    }
}
