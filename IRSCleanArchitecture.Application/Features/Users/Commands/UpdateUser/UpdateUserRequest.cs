using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.UpdateUser
{
    public sealed record UpdateUserRequest(int Id, string Email, string Name) : IRequest<UpdateUserResponse>;
}
