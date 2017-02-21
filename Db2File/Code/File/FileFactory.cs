using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db2File.Code.Common;

namespace Db2File.Code.File
{
    static class FileFactory
    {
        public static IFileWriter CreateFileWriter(FileSettings settings)
        {
            switch (settings.FileType)
            {
                case FileType.DBF:
                    {
                        return new DbfFileWriter(settings.FileName, settings.FileEncoding, settings.ColumnRelations);
                    }

                case FileType.CSV:
                    {
                        var fileWriter = new CsvFileWriter(settings.FileName, settings.FileEncoding, settings.ColumnRelations);
                        fileWriter.Delimiter = settings.Delimiter;
                        fileWriter.NumberDecimalSeparator = settings.NumberDecimalSeparator;
                        return fileWriter;
                    }

                case FileType.XLSX:
                    {
                        var fileWriter = new ExcelFileWriter(settings.FileName, settings.FileEncoding, settings.ColumnRelations);
                        fileWriter.SheetName = settings.SheetName;
                        return fileWriter;
                    }

                default:
                    {
                        throw new ArgumentException("Unknown file type.");
                    }
            }
        }

        public static IFileColumn CreateFileColumn(FileType fileType)
        {
            switch (fileType)
            {
                case FileType.DBF:
                    {
                        return new DbfFileColumn();
                    }
                case FileType.CSV:
                    {
                        return new CsvFileColumn();
                    }
                case FileType.XLSX:
                    {
                        return new ExcelFileColumn();
                    }
                default:
                    {
                        throw new ArgumentException("Unknown file type.");
                    }
            }
        }
    }
}
