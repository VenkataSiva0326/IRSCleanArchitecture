using AutoMapper;
using IRSCleanArchitecture.Application.Features.Users.Commands.CreateUser;
using IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser;
using IRSCleanArchitecture.Application.Features.Users.Commands.UpdateUser;
using IRSCleanArchitecture.Application.Features.Users.Queries.GetAllUser;
using IRSCleanArchitecture.Application.Features.Users.Queries.GetUserById;
using IRSCleanArchitecture.Domain.Entities;

namespace IRSCleanArchitecture.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
            CreateMap<User, GetAllUserQuery>().ReverseMap();
            CreateMap<User, GetUserByIdQueryRequest>().ReverseMap();
            CreateMap<User,UserListVm>().ReverseMap();
            CreateMap<User, UserDetailsVm>().ReverseMap();
            CreateMap<User, CreateUserCommandResponse>().ReverseMap();
            CreateMap<User,UpdateUserCommandResponse>().ReverseMap();
            CreateMap<User, DeleteUserCommandResponse>().ReverseMap();



        }
    }
}
