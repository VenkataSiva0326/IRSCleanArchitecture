using IRSCleanArchitecture.Application.Features.Users.Commands.UpdateUser;
using IRSCleanArchitecture.Domain.Entities;
using Moq;
using IRSCleanArchitecture.Application.Interfaces;
using AutoMapper;
using IRSCleanArchitecture.Test.Mocks;
using IRSCleanArchitecture.Application.Profiles;

namespace IRSCleanArchitecture.Test.Application.Users.Commands
{
    public class UpdateUserTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IMapper _mapper;

        public UpdateUserTests()
        {
            _mockUserRepository = RepositoryMocks.GetUsersRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task should_Update_user_when_command_valid()
        {
            var command = new UpdateUserCommand { Id=1,Email="Test@Test.com",Name="Test User" };

            var user = new User()
            {
                Id = command.Id
            };
            var mockRepo = _mockUserRepository;
            mockRepo.Setup(r => r.GetUserById(It.IsAny<int>(),CancellationToken.None))
                   .ReturnsAsync(new User());

            var sut = new UpdateUserCommandHandler(_mockUserRepository.Object, _mapper);
            await sut.Handle(command, CancellationToken.None);

            mockRepo.Verify(m => m.UpdateUser(It.IsAny<User>()), Times.Once());
        }
    }
}
