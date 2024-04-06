using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSCleanArchitecture.Domain.Entities;

namespace IRSCleanArchitecture.Application.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email, CancellationToken cancellationToken);

        Task<User> CreateUser(User entity);
        Task<User> UpdateUser(User entity);
        Task<User> DeleteUser(int? id);
        Task<User> GetUserById(int? id, CancellationToken cancellationToken);
        Task<List<User>> GetAllUsers(CancellationToken cancellationToken);
    }
}
