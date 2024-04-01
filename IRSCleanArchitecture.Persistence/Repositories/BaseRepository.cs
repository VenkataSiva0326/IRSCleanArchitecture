using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Domain.Entities;

namespace IRSCleanArchitecture.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
