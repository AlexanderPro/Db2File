using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Globalization;
using Db2File.Code.Common;

namespace Db2File.Code.File
{
    class CsvFileWriter : IFileWriter
    {
        private static CultureInfo _decimalCultureInfo;
        private String _fileName;
        private Encoding _fileEncoding;
        private StreamWriter _fileWriter;
        private IList<ColumnRelation> _columnRelations;
        private Boolean _disposed;

        public String Delimiter { get; set; }

        public String NumberDecimalSeparator
        {
            get
            {
                return _decimalCultureInfo.NumberFormat.NumberDecimalSeparator;
            }
            set
            {
                _decimalCultureInfo.NumberFormat.NumberDecimalSeparator = value;
            }
        }

        static CsvFileWriter()
        {
            _decimalCultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            _decimalCultureInfo.NumberFormat.NumberDecimalSeparator = ".";
        }

        public CsvFileWriter(String fileName, Encoding fileEncoding, IList<ColumnRelation> columnRelations)
        {
            _disposed = false;
            _fileName = fileName;
            _fileEncoding = fileEncoding;
            _columnRelations = columnRelations;
            _fileWriter = new StreamWriter(fileName, false, fileEncoding);
            Delimiter = ";";
        }

        public void CreateHeader()
        {
            var header = String.Join(Delimiter, _columnRelations.Select(r => ColumnToString(r.FileColumnName)));
            _fileWriter.WriteLine(header);
        }

        public void Write(IDataReader reader)
        {
            while (reader.Read())
            {
                var columns = new List<String>();
                foreach (var relation in _columnRelations)
                {
                    columns.Add(ColumnToString(reader[relation.DbColumnName], relation.FileColumnFormat));
                }
                var line = String.Join(Delimiter, columns);
                _fileWriter.WriteLine(line);
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_fileWriter != null) _fileWriter.Dispose();
                _disposed = true;
            }
        }

        private String ColumnToString(Object @value, String format = "")
        {
            String result = "";

            if (@value is DateTime)
            {
                format = String.IsNullOrWhiteSpace(format) ? "yyyy-MM-dd" : format;
                result = ((DateTime)@value).ToString(format);
            }

            if (@value is IFormattable && !String.IsNullOrWhiteSpace(format))
            {
                result = ((IFormattable)@value).ToString(format, _decimalCultureInfo);
            }
            else
            if (@value is IConvertible)
            {
                result = ((IConvertible)@value).ToString(_decimalCultureInfo);
            }

            result = result.Replace(Environment.NewLine, " ");
            if (result.Contains(Delimiter) || result.Contains('"'))
            {
                result = String.Format("\"{0}\"", result.Replace("\"", "\"\""));
            }
            return result;
        }
    }
}
