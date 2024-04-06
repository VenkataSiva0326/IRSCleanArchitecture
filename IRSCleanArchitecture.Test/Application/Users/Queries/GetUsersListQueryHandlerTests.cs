using AutoMapper;
using FluentAssertions;
using IRSCleanArchitecture.Application.Profiles;
using IRSCleanArchitecture.Application.Features.Users.Queries.GetAllUser;
using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Test.Mocks;
using Moq;

namespace IRSCleanArchitecture.Test.Application.Users.Queries
{
    public class GetUsersListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockUserRepository;


        public GetUsersListQueryHandlerTests()
        {
            _mockUserRepository = RepositoryMocks.GetUsersRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetAllUserQueryHandler(_mockUserRepository.Object, _mapper);

            var result = await handler.Handle(new GetAllUserQuery(), CancellationToken.None);

            result.Should().BeOfType<List<UserListVm>>();

            result.Count.Should().Be(4);
        }
    }
}
