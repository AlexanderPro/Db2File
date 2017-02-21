using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db2File.Code.File
{
    interface IFileColumn
    {
        IList<String> GetSupportedTypes();
    }
}
