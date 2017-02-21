using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Globalization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Db2File.Code.Common;

namespace Db2File.Code.File
{
    class ExcelFileWriter : IFileWriter
    {
        private static CultureInfo _decimalCultureInfo;
        private ExcelPackage _package;
        private IList<ColumnRelation> _columnRelations;
        private Boolean _disposed;

        public String SheetName { get; set; }

        static ExcelFileWriter()
        {
            _decimalCultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            _decimalCultureInfo.NumberFormat.NumberDecimalSeparator = ".";
        }

        public ExcelFileWriter(String fileName, Encoding fileEncoding, IList<ColumnRelation> columnRelations)
        {
            _disposed = false;
            _columnRelations = columnRelations;
            _package = new ExcelPackage(new FileInfo(fileName));
            SheetName = "Sheet1";
        }

        public void CreateHeader()
        {
            var sheet = _package.Workbook.Worksheets[SheetName] != null ? _package.Workbook.Worksheets[SheetName] : _package.Workbook.Worksheets.Add(SheetName);
            for (Int32 i = 0; i < _columnRelations.Count; i++)
            {
                sheet.Cells[1, i + 1].Value = _columnRelations[i].FileColumnName;
                sheet.Cells[1, i + 1].Style.Numberformat.Format = GetCellFormat(_columnRelations[i].FileColumnName);
                sheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
        }

        public void Write(IDataReader reader)
        {
            var sheet = _package.Workbook.Worksheets[SheetName] != null ? _package.Workbook.Worksheets[SheetName] : _package.Workbook.Worksheets.Add(SheetName);
            var rowIndex = 2;
            while (reader.Read())
            {
                var columns = new List<String>();
                for (Int32 i = 0; i < _columnRelations.Count; i++)
                {
                    sheet.Cells[rowIndex, i + 1].Value = reader[_columnRelations[i].DbColumnName];
                    sheet.Cells[rowIndex, i + 1].Style.Numberformat.Format = GetCellFormat(reader[_columnRelations[i].DbColumnName], _columnRelations[i].FileColumnFormat);
                }
                rowIndex++;
            }
            sheet.Cells.AutoFitColumns(0);
            _package.Save();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_package != null) _package.Dispose();
                _disposed = true;
            }
        }

        private String GetCellFormat(Object @value, String format = "")
        {
            if (@value is DateTime)
            {
                var dateTime = (DateTime)@value;
                if (dateTime.TimeOfDay.TotalMilliseconds > 0)
                {
                    format = String.IsNullOrWhiteSpace(format) ? "yyyy-MM-dd hh:mm:ss" : format;
                }
                else
                {
                    format = String.IsNullOrWhiteSpace(format) ? "yyyy-MM-dd" : format;
                }
                return format;
            }

            if (@value is Double || @value is Single || @value is Decimal)
            {
                format = String.IsNullOrWhiteSpace(format) ? "#,##0.00" : format;
                return format;
            }

            if (@value is SByte || @value is Byte || @value is Int16 || @value is UInt16 || @value is Int32 || @value is UInt32 || @value is Int64 || @value is UInt64)
            {
                format = String.IsNullOrWhiteSpace(format) ? "#,##0" : format;
                return format;
            }

            return "@";
        }
    }
}
