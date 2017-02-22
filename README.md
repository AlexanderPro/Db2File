Db2File
=============

This  app exports data from DB to dbf, csv and xlsx file.
The program supports three types of DB involving native ADO.NET providers: Postgres, MsSql, Oracle.
It is also possible to connect to DB by means of the following providers: OleDb and Odbc.
If necessary, the number of supported db can be extended. 
The file encoding can be set with a string or a number.
A part of the settings is saved in Db2File.exe.config file:

* DefaultFileEncoding is a default file encoding.
* CsvCharDelimiter is a delimiter used in csv file.
* NumberDecimalSeparator is a decimal number separator used in the result file.
* DefaultExcelSheetName is a default excel sheet name where the result is recorded.
* columnRelations is a section where column relations are described.

Export to DBF File
------------------

Now a few main file encodings are supported: 1251, 1252, 866, etc.

columnRelations section attributes:
* dbColumnName is a database column name.
* fileColumnName is a file column name.
* fileColumnType is a file column type.
* fileColumnLength is a file column length. For a string of one hundred chars the value will be 100.
* fileColumnDecimals is a number of digits after the dot for decimal numbers.

Export to CSV File
------------------

columnRelations section attributes:
* dbColumnName is a database column name.
* fileColumnName is a file column name.
* fileColumnFormat  is a file column format for dates, numbers and etc. It is set as C# format. There is no default format and the app uses the most preferable. E.g:
 1. dd.MM.yyyy is a date format.
 2. dd.MM.yyyy HH:mm:ss is a date and time format.
 3. 0.00 is a number with two digits after the dot.
 4. etc.

Export to Excel File
--------------------

Now xlsx files are supported.

columnRelations section attributes:
* dbColumnName is a database column name.
* fileColumnName is a file column name.
* fileColumnFormat  is a file column format for dates, numbers and etc. It is set as Open Office Xml format. There is no default format and the app uses the most preferable. E.g:
 1. yyyy-MM-dd is a date format.
 2. yyyy-MM-dd hh:mm:ss is a date and time format.
 3. #,##0.00 is a number with two digits after the dot.
 4. etc.

