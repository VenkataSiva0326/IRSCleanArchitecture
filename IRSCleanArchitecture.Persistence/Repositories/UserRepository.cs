using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Domain.Entities;
using IRSCleanArchitecture.Persistence.DbContext;
using static Dapper.SqlMapper;

namespace IRSCleanArchitecture.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            throw new NotImplementedException();
        }


        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        public Task<User> GetByEmail(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public async Task<User> CreateUser(User entity)
        {
            using (var db = _context.CreateConnection())
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@email", entity.Email);
                    parameters.Add("@name", entity.Name);
                    var result = await db.QuerySingleAsync<User>("CreateUser", parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<User> GetUserById(int?  id, CancellationToken cancellationToken)
        {
            using (var db = _context.CreateConnection())
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@userId", id);
                    var result = await db.QuerySingleAsync<User>("GetUserById", parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<User> UpdateUser(User entity)
        {
            using (var db = _context.CreateConnection())
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@userId", entity.Id);
                    parameters.Add("@email", entity.Email);
                    parameters.Add("@name", entity.Name);
                    var result = await db.QuerySingleAsync<User>("UpdateUserById", parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<User> DeleteUser(int? id)
        {
            using (var db = _context.CreateConnection())
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@userId", id);
                    var result = await db.QuerySingleAsync<User>("DeleteUser", parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<List<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            using (var db = _context.CreateConnection())
            {
                try
                {
                    var result = await db.QueryAsync<User>("GetAllUsers", commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

    }
}
