using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db2File.Code.Common;

namespace Db2File.Code.File
{
    class FileSettings
    {
        public FileType FileType { get; set; }

        public String FileName { get; set; }

        public Encoding FileEncoding { get; set; }

        public IList<ColumnRelation> ColumnRelations { get; set; }

        public String Delimiter { get; set; }

        public String NumberDecimalSeparator { get; set; }

        public String SheetName { get; set; }
    }
}
