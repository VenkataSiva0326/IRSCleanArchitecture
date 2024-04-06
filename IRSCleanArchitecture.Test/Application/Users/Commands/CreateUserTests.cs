using AutoMapper;
using FluentAssertions;
using IRSCleanArchitecture.Application.Features.Users.Commands.CreateUser;
using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Application.Profiles;
using IRSCleanArchitecture.Test.Mocks;
using Moq;

namespace IRSCleanArchitecture.Test.Application.Users.Commands
{
    public class CreateUserTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockUserRepository;

        public CreateUserTests()
        {
            _mockUserRepository = RepositoryMocks.GetUsersRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidUser_AddedToUsersRepo()
        {
            var handler = new CreateUserCommandHandler(_mockUserRepository.Object, _mapper);

            var createdUserResponse = await handler.Handle(new CreateUserCommand() { Email = "Test@Test.com", Name = "Test" }, CancellationToken.None);

            createdUserResponse.Should().NotBeNull();

            var allCategories = await _mockUserRepository.Object.GetAllUsers(CancellationToken.None);

            allCategories.Count.Should().Be(5);
        }
    }
}
