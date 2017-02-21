using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db2File.Code.File
{
    class DbfFileColumn : IFileColumn
    {
        public IList<String> GetSupportedTypes()
        {
            var types = new List<String>
            {
                "Character",
                "Number",
                "Boolean",
                "Date",
                "Memo",
                "Binary",
                "Integer",
                "Float"
            };
            return types;
        }
    }
}
