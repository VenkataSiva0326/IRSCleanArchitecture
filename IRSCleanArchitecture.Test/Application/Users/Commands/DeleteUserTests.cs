using AutoMapper;
using FluentAssertions;
using IRSCleanArchitecture.Application.Features.Users.Commands.DeleteUser;
using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Application.Profiles;
using IRSCleanArchitecture.Test.Mocks;
using Moq;

namespace IRSCleanArchitecture.Test.Application.Users.Commands
{
    public class DeleteUserTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockUserRepository;

        public DeleteUserTests()
        {
            _mockUserRepository = RepositoryMocks.GetUsersRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidUser_DeletedFromUsersRepo()
        {
            var handler = new DeleteUserCommandHandler(_mockUserRepository.Object, _mapper);

            var deletedUserResponse = await handler.Handle(new DeleteUserCommand() { Id = 1 }, CancellationToken.None);

            deletedUserResponse.Should().BeNull();
            //var allCategories = await _mockUserRepository.Object.GetAllUsers(CancellationToken.None);

            //allCategories.Count.Should().BeLessThan(4);
        }
    }
}
