using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser;
using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQueryRequest(int Id) : IRequest<GetUserByIdQueryResponse>
    {
    }
}
