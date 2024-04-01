using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace IRSCleanArchitecture.Persistence.DbContext
{
    public class DapperContext
    {
        private readonly DapperSettings _dapperSettings;

        public DapperContext(IOptions<DapperSettings> DapperSettings)
        {
            _dapperSettings = DapperSettings.Value;
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_dapperSettings.SqlServer);

    }
}
