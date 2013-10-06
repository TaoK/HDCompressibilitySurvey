using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDSurvey
{
    struct FileCompressionInfo
    {
        public string FullName { get; set; }
        public long FileSize { get; set; }
        public long TestedSize { get; set; }
        public long TestResultBytes { get; set; }
        public float CompressionRatio
        {
            get
            {
                return (TestedSize - TestResultBytes) * 1.0f / TestedSize;
            }
        }
    }
}
