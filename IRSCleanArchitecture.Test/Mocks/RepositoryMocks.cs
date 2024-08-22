using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Domain.Entities;
using Moq;

namespace IRSCleanArchitecture.Test.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IUserRepository> GetUsersRepository()
        {


            var usersList = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "Test@Test.com",
                    Name = "Test1 User"
                },
                new User
                {
                    Id = 2,
                    Email = "Test@Test.com",
                    Name = "Test2 User"
                },
                new User
                {
                    Id = 3,
                    Email = "Test@Test.com",
                    Name = "Test3 User"
                },
                new User
                {
                    Id = 4,
                    Email = "Test@Test.com",
                    Name = "Test4 User"
                }
            };

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetAllUsers(CancellationToken.None)).ReturnsAsync(usersList);
            mockUserRepository.Setup(repo => repo.GetUserById(It.IsAny<int>(),CancellationToken.None)).ReturnsAsync(new User());

            mockUserRepository.Setup(repo => repo.CreateUser(It.IsAny<User>())).ReturnsAsync(
                (User user) =>
                {
                    usersList.Add(user);
                    return user;
                });
            mockUserRepository.Setup(repo => repo.DeleteUser(It.IsAny<int>())).ReturnsAsync(
                (User user) =>
                {
                    usersList.Remove(user);
                    return user;
                });

            return mockUserRepository;
        }
    }
}
