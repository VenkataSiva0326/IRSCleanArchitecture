using AutoMapper;
using FluentAssertions;
using IRSCleanArchitecture.Application.Features.Users.Queries.GetUserById;
using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Application.Profiles;
using IRSCleanArchitecture.Test.Mocks;
using Moq;

namespace IRSCleanArchitecture.Test.Application.Users.Queries
{
    public class GetUserDetailsByIdQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockUserRepository;


        public GetUserDetailsByIdQueryHandlerTests()
        {
            _mockUserRepository = RepositoryMocks.GetUsersRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetUserByIdTest()
        {
            var handler = new GetUserByIdQueryHandler(_mockUserRepository.Object, _mapper);

            var result = await handler.Handle(new GetUserByIdQueryRequest(1) { Id = 1 }, CancellationToken.None);

            result.Should().BeOfType<UserDetailsVm>();
        }
    }
}
