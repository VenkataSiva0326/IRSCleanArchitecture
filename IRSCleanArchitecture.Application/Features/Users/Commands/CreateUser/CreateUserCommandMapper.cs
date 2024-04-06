using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRSCleanArchitecture.Domain.Entities;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserCommandMapper : Profile
    {
        public CreateUserCommandMapper()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, CreateUserCommandResponse>();
        }
    }
}
