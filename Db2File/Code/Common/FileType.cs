using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Db2File.Code.Common
{
    enum FileType : int
    {
        [Description("DBF")]
        DBF = 0x01,

        [Description("CSV")]
        CSV = 0x02,

        [Description("XLSX")]
        XLSX = 0x03
    }
}
