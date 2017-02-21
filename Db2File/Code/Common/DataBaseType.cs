using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Db2File.Code.Common
{
    enum DataBaseType : int
    {
        [Description("PostgreSQL")]
        [InvariantName("Npgsql")]
        Postgres = 0x01,

        [Description("MsSql")]
        [InvariantName("System.Data.SqlClient")]
        MsSql = 0x02,

        [Description("Oracle")]
        [InvariantName("System.Data.OracleClient")]
        Oracle = 0x03,

        [Description("OleDb")]
        [InvariantName("System.Data.OleDb")]
        OleDb = 0x04,

        [Description("Odbc")]
        [InvariantName("System.Data.Odbc")]
        Odbc = 0x05
    }
}
