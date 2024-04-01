using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser
{
    public sealed record DeleteUserRequest(int Id) : IRequest<DeleteUserResponse>
    {
    }
}
