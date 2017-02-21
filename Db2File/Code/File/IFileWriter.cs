using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Db2File.Code.File
{
    interface IFileWriter : IDisposable
    {
        void CreateHeader();
        void Write(IDataReader reader);
    }
}
