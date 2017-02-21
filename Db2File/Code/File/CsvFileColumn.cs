using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db2File.Code.File
{
    class CsvFileColumn : IFileColumn
    {
        public IList<String> GetSupportedTypes()
        {
            var types = new List<String>();
            return types;
        }
    }
}
