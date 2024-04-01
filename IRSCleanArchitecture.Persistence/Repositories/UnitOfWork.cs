using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRSCleanArchitecture.Application.Interfaces;
using IRSCleanArchitecture.Persistence.DbContext;

namespace IRSCleanArchitecture.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DapperContext _context;

        public UnitOfWork(DapperContext context)
        {
            _context = context;
        }
    }

}
