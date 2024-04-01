using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSCleanArchitecture.Persistence.DbContext
{
    public class DapperSettings
    {
        public const string SectionName = "ConnectionStrings";

        public string SqlServer { get; set; } = null!;
    }
}
