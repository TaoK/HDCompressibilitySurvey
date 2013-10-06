using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Principal;

namespace HDSurvey
{
	public partial class SurveyForm : Form
	{
        private const string COMPRESSED_EXTENSIONS_FILE = "compressed_extensions_data.txt";

        public SurveyForm()
		{
			InitializeComponent();
		}

        //private FileDataCollector Collector;
        internal FileExtensionDataCollection Data { get; private set; }
        internal DateTime? StartDateTime { get; private set; }
        internal DateTime? CollectionDateTime { get; private set; }
        internal DateTime? CompressionTestDateTime { get; private set; }


        private void btn_Go_Click(object sender, EventArgs e)
        {
            btn_Go.Enabled = false;
            lbl_OverallStatus.Text = "In Progress...";
            backgroundWorker1.RunWorkerAsync();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            btn_Stop.Enabled = false;
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            //TODO: reset compiled data;

            long fileCounter = 0;
            StartDateTime = DateTime.Now;
            CollectionDateTime = null;
            CompressionTestDateTime = null;

            foreach (var file in SafeFileEnumerator.EnumerateFiles(txt_BasePath.Text, "*.*", SearchOption.AllDirectories))
            {
                Data.AddFile(file);
                fileCounter++;

                if (fileCounter % 5000 == 0)
                {
                    worker.ReportProgress(0);

                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //force refresh
            worker.ReportProgress(0);

            CollectionDateTime = DateTime.Now;
            fileCounter = 0;
            Random rnd = new Random();
            int minFileCountToTest = int.Parse(txt_MinFileCount.Text);

            using (var compressionTester = new FileCompressionTester(int.Parse(txt_MaxTestBytes.Text)))
            {
                foreach (var extensionPilePair in Data)
                {
                    if (!extensionPilePair.KnownCompressed || chk_TestKnownTypes.Checked)
                    {
                        int fileCountToTest = minFileCountToTest;
                        if (extensionPilePair.Files.Files.Count / 10 > fileCountToTest)
                            fileCountToTest = extensionPilePair.Files.Files.Count / 10;

                        foreach (var file in extensionPilePair.Files.Files.Shuffle(rnd).Take(fileCountToTest))
                        {
                            fileCounter++;
                            int thisTestByteLength = 0;
                            int thisTestOutputLength = 0;

                            if (compressionTester.TestCompressionRatio(file.FullName, out thisTestByteLength, out thisTestOutputLength) != null)
                                Data.AddCompressionStat(file, thisTestByteLength, thisTestOutputLength);
                            else
                                //TODO: think about how to pass error message around
                                Data.AddErrorEntry(file, "Unknown");

                            if (fileCounter % 10 == 0)
                            {
                                worker.ReportProgress(0);

                                if (worker.CancellationPending == true)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            CompressionTestDateTime = DateTime.Now;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //var worker = sender as BackgroundWorker;

            UpdateStatus();

            if (e.Cancelled)
                lbl_OverallStatus.Text = "Cancelled.";
            else if (e.Error != null)
                lbl_OverallStatus.Text = "Error: " + e.Error.ToString();
            else
                lbl_OverallStatus.Text = "Completed!";

            btn_Go.Enabled = true;
            btn_Stop.Enabled = false;

            if (CollectionDateTime.HasValue && CompressionTestDateTime.HasValue)
                btn_Export.Enabled = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!btn_Stop.Enabled)
                btn_Stop.Enabled = true;

            UpdateStatus();
        }

        private void UpdateStatus()
        {
            if (!CollectionDateTime.HasValue)
            {
                lbl_CollectionTimeValue.Text = (DateTime.Now - StartDateTime.Value).DisplaySecs();
                lbl_CompressionTimeValue.Text = "...";
                lbl_OverallStatus.Text = "Collecting File Data...";
            }
            else
            {
                lbl_CollectionTimeValue.Text = (CollectionDateTime.Value - StartDateTime.Value).DisplaySecs();

                if (!CompressionTestDateTime.HasValue)
                {
                    lbl_CompressionTimeValue.Text = (DateTime.Now - CollectionDateTime.Value).DisplaySecs();
                    lbl_OverallStatus.Text = "Testing Compression...";
                }
                else
                {
                    lbl_CompressionTimeValue.Text = (CompressionTestDateTime.Value - CollectionDateTime.Value).DisplaySecs();
                    lbl_OverallStatus.Text = "Done?";
                }

            }

            UpdateExtensionData(Data);
        }

        private void UpdateExtensionData(FileExtensionDataCollection data)
        {
            lock (data)
            {
                //TODO: pre-aggregate more stuff to avoid all this pointless aggregation/churning in display functionality.

                dgv_Extensions.DataSource = data.OrderBy(a => a.CompressionStats.AvgCompressionRatio ?? 1000).Select(a => new
                {
                    Extension = a.Extension,
                    TotalFileCount = a.Files.Files.Count,
                    TotalFileSize = a.Files.TotalFileSize.FormatFileSize(),
                    TestedFileCount = a.CompressionStats.CompressionResults.Count,
                    TestedFileSize = a.CompressionStats.CompressionResults.Aggregate(0L, (sum, item) => sum += item.TestedSize).FormatFileSize(),
                    TestResultFileSize = a.CompressionStats.CompressionResults.Aggregate(0L, (sum, item) => sum += item.TestResultBytes).FormatFileSize(),
                    AvgCompression = a.CompressionStats.AvgCompressionRatio == null ? "" : a.CompressionStats.AvgCompressionRatio.Value.ToString("0.0%"),
                    Known = a.KnownCompressed,
                    Description = a.Description,
                    Category = a.Category
                }).ToList();

                lbl_ExtensionsFoundValue.Text = data.Count.ToString();
                lbl_TotalFilesFoundValue.Text = data.Aggregate(0L, (count, pile) => count + pile.Files.Files.Count).ToString();
                lbl_TotalFileSizeValue.Text = data.Aggregate(0L, (size, pile) => size + pile.Files.TotalFileSize).FormatFileSize();
                lbl_ExtensionsTestedValue.Text = data.Where(a => a.CompressionStats.CompressionResults.Count > 0).Count().ToString();
                lbl_FilesTestedValue.Text = data.Aggregate(0, (count, pile) => count + pile.CompressionStats.CompressionResults.Count).ToString();
                lbl_TestedSizeValue.Text = data.Aggregate(0L, (size, pile) => size + pile.CompressionStats.CompressionResults.Aggregate(0L, (innerSize, testedFile) => innerSize += testedFile.TestedSize)).FormatFileSize();
                lbl_TestResultSizeValue.Text = data.Aggregate(0L, (size, pile) => size + pile.CompressionStats.CompressionResults.Aggregate(0L, (innerSize, testedFile) => innerSize += testedFile.TestResultBytes)).FormatFileSize();
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Data.ExportToExcel(saveFileDialog1.FileName, chk_IncludeFileDetails.Checked);
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txt_BasePath.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_BasePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SurveyForm_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            Data = new FileExtensionDataCollection(StringComparer.OrdinalIgnoreCase);
            LoadCompressedList();
            UpdateExtensionData(Data);
        }

        private void LoadCompressedList()
        {
            var targetFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), COMPRESSED_EXTENSIONS_FILE);
            if (File.Exists(targetFile))
            {
                string latestCategory = null;

                foreach (var targetLine in File.ReadLines(targetFile))
                {
                    var hashSplit = targetLine.Split('#');
                    string beforeHash = hashSplit[0].Trim();
                    string afterHash = string.Join("#", hashSplit.Skip(1)).Trim();

                    if (beforeHash == "" && afterHash != "")
                    {
                        //This is a category name - replace whatever the last one was for new entries
                        latestCategory = afterHash;
                    }
                    else if (beforeHash != "")
                    {
                        //This is an extension, which may or may not have a description
                        var group = Data.GetGroup(beforeHash, afterHash);
                        group.Category = latestCategory;
                        group.KnownCompressed = true;
                    }
                }
            }
        }

        private void dgv_Extensions_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Extensions.SelectedRows.Count <= 1 && e.RowIndex >= 0 && !splitContainer1.Panel2Collapsed)
            {
                var extension = dgv_Extensions.Rows[e.RowIndex].Cells[0].Value.ToString();
                dgv_Files.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgv_Files.DataSource = Data[extension].CompressionStats.CompressionResults.Select(a => new
                {
                    FileName = a.FullName,
                    Size = a.FileSize.FormatFileSize(),
                    TestedSize = a.TestedSize.FormatFileSize(),
                    ResultSize = a.TestResultBytes.FormatFileSize(),
                    Compression = a.CompressionRatio.ToString("0.0%")
                }).OrderBy(a => a.FileName).ToList();
            }
        }

        private void btn_Expand_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = false;
            btn_Expand.Enabled = false;
        }

        private void btn_Collapse_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            btn_Expand.Enabled = true;
        }

        private void dgv_Extensions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Expand_Click(sender, null);
            dgv_Extensions_RowEnter(sender, e);
        }

        private void SurveyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TODO: figure out why LZMA library keeps a thread around always... would be nice not to have to force-kill...
            Application.Exit();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Sorry, not yet implemented! Please manually edit the '{0}' file...", COMPRESSED_EXTENSIONS_FILE));
        }
	}
}
