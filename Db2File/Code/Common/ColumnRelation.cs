using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db2File.Code.Common
{
    class ColumnRelation
    {
        public String DbColumnName { get; set; }

        public String FileColumnName { get; set; }

        public String FileColumnFormat { get; set; }

        public String FileColumnType { get; set; }

        public Int32? FileColumnLength { get; set; }

        public Int32? FileColumnDecimals { get; set; }
    }
}
