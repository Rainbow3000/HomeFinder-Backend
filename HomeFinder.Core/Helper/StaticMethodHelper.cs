using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Helper
{
    public static class StaticMethodHelper
    {
        public static int? SafeGetInt(this DbDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            return null;
        }
    }
}
