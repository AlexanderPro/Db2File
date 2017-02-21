using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Npgsql;
using Db2File.Code.Common;
using Db2File.Code.File;

namespace Db2File.Code.Forms
{
    public partial class MainForm : Form
    {
        private volatile Boolean _isOperationInAction;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                InitializeControlsFromConfig();
            }
            catch (Exception ex)
            {
                btnExecute.Enabled = false;
                btnTestConnection.Enabled = false;
                MessageBox.Show("Failed to read configuration file. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            InitializeControls();
            InitializeProgressBar();
            InitializeStopWatch();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_isOperationInAction)
            {
                var result = MessageBox.Show("Are you sure you want to cancel the task?", "Warning", MessageBoxButtons.YesNo);
                e.Cancel = result != DialogResult.Yes;
            }
            base.OnClosing(e);
        }

        private void ButtonExecuteClick(object sender, EventArgs e)
        {
            Encoding encoding = null;
            try
            {
                var encodingPage = 0;
                encoding = Int32.TryParse(txtFileEncoding.Text, out encodingPage) ? Encoding.GetEncoding(encodingPage) : Encoding.GetEncoding(txtFileEncoding.Text);
            }
            catch
            {
                MessageBox.Show("You should set a valid file encoding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var columnRelations = new List<ColumnRelation>();
            try
            {
                foreach (DataGridViewRow row in gridColumnRelations.Rows)
                {
                    var dbColumnName = (String)row.Cells[1].Value;
                    var fileColumnName = (String)row.Cells[2].Value;
                    var fileColumnFormat = (String)row.Cells[3].Value;
                    var fileColumnType = (String)row.Cells[4].Value;
                    var fileColumnLengthString = (String)row.Cells[5].Value;
                    var fileColumnDecimalsString = (String)row.Cells[6].Value;

                    if (String.IsNullOrWhiteSpace(dbColumnName)) throw new Exception("Field \"DB Column Name\" must not be empty.");
                    if (String.IsNullOrWhiteSpace(fileColumnName)) throw new Exception("Field \"File Column Name\" must not be empty.");

                    var fileColumnLength = String.IsNullOrWhiteSpace(fileColumnLengthString) ? (Int32?)null : (Int32?)Int32.Parse(fileColumnLengthString);
                    var fileColumnDecimals = String.IsNullOrWhiteSpace(fileColumnDecimalsString) ? (Int32?)null : (Int32?)Int32.Parse(fileColumnDecimalsString);
                    var columnRelation = new ColumnRelation
                    {
                        DbColumnName = dbColumnName,
                        FileColumnName = fileColumnName,
                        FileColumnFormat = fileColumnFormat,
                        FileColumnType = fileColumnType,
                        FileColumnLength = fileColumnLength,
                        FileColumnDecimals = fileColumnDecimals
                    };
                    columnRelations.Add(columnRelation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taskSettings = new TaskSettings();
            taskSettings.ProviderInvariantName = ((DataBaseType)cmbDataBase.SelectedValue).GetInvariantName();
            taskSettings.ConnectionString = txtConnectionString.Text;
            taskSettings.Query = txtQuery.Text;
            taskSettings.FileSettings = new FileSettings();
            taskSettings.FileSettings.FileType = (FileType)cmbFileType.SelectedValue;
            taskSettings.FileSettings.FileName = txtFilePath.Text;
            taskSettings.FileSettings.FileEncoding = encoding;
            taskSettings.FileSettings.ColumnRelations = columnRelations;
            taskSettings.FileSettings.Delimiter = ConfigurationManager.AppSettings["CsvCharDelimiter"];
            taskSettings.FileSettings.NumberDecimalSeparator = ConfigurationManager.AppSettings["NumberDecimalSeparator"];
            taskSettings.FileSettings.SheetName = ConfigurationManager.AppSettings["DefaultExcelSheetName"];

            btnExecute.Enabled = false;
            btnTestConnection.Enabled = false;
            _isOperationInAction = true;
            toolStripProgressBar.Visible = true;

            Task.Factory.StartNew(() =>
            {
                Execute(taskSettings);
            }).ContinueWith(t =>
            {
                btnExecute.Enabled = true;
                btnTestConnection.Enabled = true;
                _isOperationInAction = false;
                toolStripProgressBar.Visible = false;
                if (t.IsFaulted)
                {
                    Exception ex = t.Exception;
                    while (ex is AggregateException && ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("The task has been completed successfully.", "Success", MessageBoxButtons.OK);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ButtonTestClick(object sender, EventArgs e)
        {
            var taskSettings = new TaskSettings();
            taskSettings.ProviderInvariantName = ((DataBaseType)cmbDataBase.SelectedValue).GetInvariantName();
            taskSettings.ConnectionString = txtConnectionString.Text;
            taskSettings.Query = txtQuery.Text;

            btnExecute.Enabled = false;
            btnTestConnection.Enabled = false;
            _isOperationInAction = true;
            toolStripProgressBar.Visible = true;

            Task.Factory.StartNew(() =>
            {
                TestConnection(taskSettings);
            }).ContinueWith(t =>
            {
                btnExecute.Enabled = true;
                btnTestConnection.Enabled = true;
                _isOperationInAction = false;
                toolStripProgressBar.Visible = false;
                if (t.IsFaulted)
                {
                    Exception ex = t.Exception;
                    while (ex is AggregateException && ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Connection is opened successfully.", "Success", MessageBoxButtons.OK);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ButtonBrowseFileClick(object sender, EventArgs e)
        {
            var fileType = (FileType)cmbFileType.SelectedValue;
            var fileExtension = fileType.GetDescription();
            var dialog = new SaveFileDialog();
            dialog.Filter = String.Format("{0} files (*.{1})|*.{1}|All files (*.*)|*.*", fileExtension.ToUpper(), fileExtension.ToLower());
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = dialog.FileName;
            }
        }

        private void ButtonAddRelationClick(object sender, EventArgs e)
        {
            gridColumnRelations.Rows.Add();
            var fileType = (FileType)cmbFileType.SelectedValue;
            var fileColumn = FileFactory.CreateFileColumn(fileType);
            var fileColumnTypes = fileColumn.GetSupportedTypes();
            FillFileColumnTypesInGridView(gridColumnRelations, fileColumnTypes.ToList());
        }

        private void GridColumnRelationsCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                gridColumnRelations.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void ComboBoxFileTypeIndexChanged(object sender, EventArgs e)
        {
            var fileType = (FileType)cmbFileType.SelectedValue;
            var fileColumn = FileFactory.CreateFileColumn(fileType);
            var fileColumnTypes = fileColumn.GetSupportedTypes();
            FillFileColumnTypesInGridView(gridColumnRelations, fileColumnTypes.ToList());
            gridColumnRelations.Columns[3].Visible = fileType != FileType.DBF;
            gridColumnRelations.Columns[4].Visible = fileType == FileType.DBF;
            gridColumnRelations.Columns[5].Visible = fileType == FileType.DBF;
            gridColumnRelations.Columns[6].Visible = fileType == FileType.DBF;
            var fileExtension = fileType == FileType.DBF ? ".dbf" : fileType == FileType.CSV ? ".csv" : ".xlsx";
            if (!String.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                var directotyName = Path.GetDirectoryName(txtFilePath.Text);
                var fileName = Path.GetFileNameWithoutExtension(txtFilePath.Text);
                txtFilePath.Text = Path.Combine(directotyName, fileName + fileExtension);
            }
        }

        private void FillFileColumnTypesInGridView(DataGridView grid, List<String> values)
        {
            var column = (DataGridViewComboBoxColumn)grid.Columns["clmnFileColumnType"];
            if (column != null)
            {
                column.Items.Clear();
                column.Items.AddRange(values.Cast<Object>().ToArray());
            }
        }

        private void InitializeControls()
        {
            _isOperationInAction = false;

            var dataBaseTypes = Enum.GetValues(typeof(DataBaseType)).Cast<DataBaseType>().Select(t => new { Value = t, Title = t.GetDescription() }).ToList();
            cmbDataBase.ValueMember = "Value";
            cmbDataBase.DisplayMember = "Title";
            cmbDataBase.DataSource = dataBaseTypes;

            var fileTypes = Enum.GetValues(typeof(FileType)).Cast<FileType>().Select(t => new { Value = t, Title = t.GetDescription() }).ToList();
            cmbFileType.ValueMember = "Value";
            cmbFileType.DisplayMember = "Title";
            cmbFileType.DataSource = fileTypes;
        }

        private void InitializeControlsFromConfig()
        {
            txtFileEncoding.Text = ConfigurationManager.AppSettings["DefaultFileEncoding"];
            txtConnectionString.Text = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            foreach (var relation in ColumnRelationSettings.Instance.ColumnRelations)
            {
                var index = gridColumnRelations.Rows.Add();
                var row = gridColumnRelations.Rows[index];
                row.Cells[1].Value = relation.DbColumnName;
                row.Cells[2].Value = relation.FileColumnName;
                row.Cells[3].Value = relation.FileColumnFormat;
                row.Cells[4].Value = relation.FileColumnType ?? String.Empty;
                row.Cells[5].Value = relation.FileColumnLength.HasValue ? relation.FileColumnLength.Value.ToString() : String.Empty;
                row.Cells[6].Value = relation.FileColumnDecimals.HasValue ? relation.FileColumnDecimals.Value.ToString() : String.Empty;
            }
        }

        private void InitializeProgressBar()
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                while (true)
                {
                    try
                    {
                        if (_isOperationInAction)
                        {
                            this.Invoke(() => { toolStripProgressBar.Value = 0; });
                            for (Int32 i = 0; i < toolStripProgressBar.Maximum; i += 10)
                            {
                                if (!_isOperationInAction) break;
                                this.Invoke(() => { toolStripProgressBar.PerformStep(); });
                                Thread.Sleep(100);
                            }
                        }
                        Thread.Sleep(500);
                    }
                    catch (ObjectDisposedException)
                    {
                    }
                    catch (InvalidOperationException)
                    {
                    }
                }
            });
        }

        private void InitializeStopWatch()
        {
            ThreadPool.QueueUserWorkItem(x =>
            {
                var dt = DateTime.Now;
                while (true)
                {
                    try
                    {
                        if (_isOperationInAction)
                        {
                            var timeSpan = DateTime.Now.Subtract(dt);
                            this.Invoke(() => { toolStripTimeSpan.Text = timeSpan.ToString("hh':'mm':'ss"); });
                        }
                        else
                        {
                            dt = DateTime.Now;
                        }
                        Thread.Sleep(1000);
                    }
                    catch (ObjectDisposedException)
                    {
                    }
                    catch (InvalidOperationException)
                    {
                    }
                }
            });
        }

        private void Execute(TaskSettings settings)
        {
            var providerFactory = DbProviderFactories.GetFactory(settings.ProviderInvariantName);
            using (var connection = providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                connection.ConnectionString = settings.ConnectionString;
                command.CommandText = settings.Query;
                connection.Open();
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                using (var fileWriter = FileFactory.CreateFileWriter(settings.FileSettings))
                {
                    fileWriter.CreateHeader();
                    fileWriter.Write(reader);
                }
            }
        }

        private void TestConnection(TaskSettings settings)
        {
            var providerFactory = DbProviderFactories.GetFactory(settings.ProviderInvariantName);
            using (var connection = providerFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    connection.ConnectionString = settings.ConnectionString;
                    command.CommandText = settings.Query;
                    connection.Open();
                }
            }
        }

        private class TaskSettings
        {
            public String ProviderInvariantName { get; set; }

            public String ConnectionString { get; set; }

            public String Query { get; set; }

            public FileSettings FileSettings { get; set; }
        }
    }
}