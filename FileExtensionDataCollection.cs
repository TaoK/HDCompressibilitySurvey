using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;

using OfficeOpenXml;

namespace HDSurvey
{
    class FileExtensionDataCollection : LookupKeyedCollection<string, FileExtensionData> 
    {
        public FileExtensionDataCollection(IEqualityComparer<string> comparer) : base(i => i.Extension, comparer) {}

        public void AddFile(FileInfo file)
        {
            lock (this)
            {
                GetGroup(file).Files.AddFile(file);
            }
        }

        public void AddCompressionStat(FileInfo file, int testedByteCount, int compressedByteCount)
        {
            lock (this)
            {
                GetGroup(file).CompressionStats.AddStat(file.FullName, file.Length, testedByteCount, compressedByteCount);
            }
        }

        public void AddErrorEntry(FileInfo file, string error)
        {
            lock (this)
            {
                GetGroup(file).ErrorLog.Add(file.FullName, error);
            }
        }

        private FileExtensionData GetGroup(FileInfo file)
        {
            return GetGroup(file.Extension, null);
        }

        public FileExtensionData GetGroup(string extension, string description)
        {
            FileExtensionData group = null;
            if (!this.TryGetValue(extension, out group))
            {
                group = new FileExtensionData(extension);
                group.Description = description ?? FileAssociations.FileExtensionFriendlyDocName(extension);
                this.Add(group);
            }
            return group;
        }

        public void ExportToExcel(string targetFileName, bool includeFileDetails)
        {
            if (File.Exists(targetFileName))
                File.Delete(targetFileName);

            using (ExcelPackage excelResultPackage = new ExcelPackage(new System.IO.FileInfo(targetFileName)))
            {
                var generalStatsSheet = excelResultPackage.Workbook.Worksheets.Add("Extension Stats");
                generalStatsSheet.Cells[1, 1].Value = "Extension";
                generalStatsSheet.Cells[1, 2].Value = "Total File Count";
                generalStatsSheet.Cells[1, 3].Value = "Total Size";
                generalStatsSheet.Cells[1, 4].Value = "Tested File Count";
                generalStatsSheet.Cells[1, 5].Value = "Tested Bytes";
                generalStatsSheet.Cells[1, 6].Value = "Compressed Bytes";
                generalStatsSheet.Cells[1, 7].Value = "Compression Ratio";
                generalStatsSheet.Cells[1, 8].Value = "Known";
                generalStatsSheet.Cells[1, 9].Value = "Description";
                generalStatsSheet.Cells[1, 10].Value = "Category";

                var i = 2;
                foreach (var extension in this)
                {
                    generalStatsSheet.Cells[i, 1].Value = extension.Extension;
                    generalStatsSheet.Cells[i, 2].Value = extension.Files.Files.Count;
                    generalStatsSheet.Cells[i, 3].Value = extension.Files.TotalFileSizeDynamic;
                    generalStatsSheet.Cells[i, 4].Value = extension.CompressionStats.CompressionResults.Count;
                    generalStatsSheet.Cells[i, 5].Value = extension.CompressionStats.CompressionResults.Aggregate(0L, (sum, entry) => sum += entry.TestedSize);
                    generalStatsSheet.Cells[i, 6].Value = extension.CompressionStats.CompressionResults.Aggregate(0L, (sum, entry) => sum += entry.TestResultBytes);
                    generalStatsSheet.Cells[i, 7].Value = extension.CompressionStats.AvgCompressionRatio;
                    generalStatsSheet.Cells[i, 8].Value = extension.KnownCompressed;
                    generalStatsSheet.Cells[i, 9].Value = extension.Description;
                    generalStatsSheet.Cells[i, 10].Value = extension.Category;
                    i++;
                }
                generalStatsSheet.Column(7).Style.Numberformat.Format = "0.00";

                if (includeFileDetails)
                {

                    var compressionDetailSheet = excelResultPackage.Workbook.Worksheets.Add("Compression Detail");
                    compressionDetailSheet.Cells[1, 1].Value = "FileName";
                    compressionDetailSheet.Cells[1, 2].Value = "Total Bytes";
                    compressionDetailSheet.Cells[1, 3].Value = "Tested Bytes";
                    compressionDetailSheet.Cells[1, 4].Value = "Compressed Bytes";
                    compressionDetailSheet.Cells[1, 5].Value = "Compression Ratio";

                    var k = 2;
                    foreach (var compressionTestFile in this.SelectMany(ext => ext.CompressionStats.CompressionResults))
                    {
                        compressionDetailSheet.Cells[k, 1].Value = compressionTestFile.FullName;
                        compressionDetailSheet.Cells[k, 2].Value = compressionTestFile.FileSize;
                        compressionDetailSheet.Cells[k, 3].Value = compressionTestFile.TestedSize;
                        compressionDetailSheet.Cells[k, 4].Value = compressionTestFile.TestResultBytes;
                        compressionDetailSheet.Cells[k, 5].Value = compressionTestFile.CompressionRatio;
                        k++;
                    }

                    compressionDetailSheet.Column(5).Style.Numberformat.Format = "0.00";

                    var errorDetailSheet = excelResultPackage.Workbook.Worksheets.Add("Error Detail");
                    errorDetailSheet.Cells[1, 1].Value = "Filename";
                    errorDetailSheet.Cells[1, 2].Value = "Error";

                    var l = 2;
                    foreach (var errorPair in this.SelectMany(ext => ext.ErrorLog))
                    {
                        errorDetailSheet.Cells[l, 1].Value = errorPair.Key;
                        errorDetailSheet.Cells[l, 2].Value = errorPair.Value;
                        l++;
                    }
                }

                excelResultPackage.Save();
            }
        }

    }
}
