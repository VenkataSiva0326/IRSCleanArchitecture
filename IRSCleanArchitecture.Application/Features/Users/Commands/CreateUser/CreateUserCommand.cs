using MediatR;

namespace IRSCleanArchitecture.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        //public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

    }
}
