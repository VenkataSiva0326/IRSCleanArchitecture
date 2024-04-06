using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser;
using IRSCleanArchitecture.Domain.Entities;

namespace IRSCleanArchitecture.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryMapper : Profile
    {
        public GetUserByIdQueryMapper()
        {
            CreateMap<GetUserByIdQueryRequest, User>();
            CreateMap<User, GetUserByIdQueryResponse>();
        }
    }
}
