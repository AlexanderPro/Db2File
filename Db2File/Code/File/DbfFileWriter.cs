using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Globalization;
using SocialExplorer.IO.FastDBF;
using Db2File.Code.Common;

namespace Db2File.Code.File
{
    class DbfFileWriter : IFileWriter
    {
        private static CultureInfo _decimalCultureInfo;
        private String _fileName;
        private Encoding _fileEncoding;
        private IList<ColumnRelation> _columnRelations;
        private DbfFile _file;
        private Boolean _disposed;

        static DbfFileWriter()
        {
            _decimalCultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            _decimalCultureInfo.NumberFormat.NumberDecimalSeparator = ".";
        }

        public DbfFileWriter(String fileName, Encoding fileEncoding, IList<ColumnRelation> columnRelations)
        {
            var columnLength = columnRelations.Where(r => !r.FileColumnLength.HasValue).Count();
            if (columnLength > 0)
            {
                throw new Exception("File Column Length must not be empty.");
            }

            _disposed = false;
            _fileName = fileName;
            _fileEncoding = fileEncoding;
            _columnRelations = columnRelations;
            _file = new DbfFile(fileEncoding);
            _file.Open(fileName, FileMode.Create);
        }

        public void CreateHeader()
        {
            foreach (var relation in _columnRelations)
            {
                var columnType = (DbfColumn.DbfColumnType)Enum.Parse(typeof(DbfColumn.DbfColumnType), relation.FileColumnType, true);
                var column = new DbfColumn(relation.FileColumnName, columnType, relation.FileColumnLength.HasValue ? relation.FileColumnLength.Value : 0, relation.FileColumnDecimals.HasValue ? relation.FileColumnDecimals.Value : 0);
                _file.Header.AddColumn(column);
            }
            _file.WriteHeader();
        }

        public void Write(IDataReader reader)
        {
            while (reader.Read())
            {
                var record = new DbfRecord(_file.Header) { AllowDecimalTruncate = true };

                foreach (var relation in _columnRelations)
                {
                    record[relation.FileColumnName] = ColumnToString(reader[relation.DbColumnName]);
                }

                _file.Write(record);
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_file != null) _file.Close();
                _disposed = true;
            }
        }

        private String ColumnToString(Object @value)
        {
            if (@value is DateTime)
            {
                return ((DateTime)@value).ToString("yyyy-MM-dd");
            }

            if (@value is IConvertible)
            {
                return ((IConvertible)@value).ToString(_decimalCultureInfo);
            }

            return @value.ToString();
        }
    }
}
