using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDSurvey
{
    class FileCompressionPile
    {
        public List<FileCompressionInfo> CompressionResults = new List<FileCompressionInfo>();

        public double? AvgCompressionRatio
        {
            get
            {
                var totalBytesTested = CompressionResults.Aggregate(0L, (bytesCount, data) => bytesCount += data.TestedSize);
                if (totalBytesTested > 0)
                {
                    var totalCompressedBytes = CompressionResults.Aggregate(0L, (bytesCount, data) => bytesCount += data.TestResultBytes);
                    return (totalBytesTested - totalCompressedBytes) * 1.0 / totalBytesTested;
                }
                else
                {
                    return null;
                }
            }
        }

        internal void AddStat(string fileName, long fullFileSize, int testedByteCount, int compressedByteCount)
        {
            CompressionResults.Add(new FileCompressionInfo { FullName = fileName, FileSize = fullFileSize, TestedSize = testedByteCount, TestResultBytes = compressedByteCount });
        }
    }
}
