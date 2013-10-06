using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDSurvey
{
    class FileExtensionData
    {
        public FileExtensionData(string extension)
        {
            Extension = extension;
            Files = new FilePile();
            CompressionStats = new FileCompressionPile();
            ErrorLog = new Dictionary<string,string>();
        }

        public string Extension { get; private set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool KnownCompressed { get; set; }
        public FilePile Files { get; private set; }
        public FileCompressionPile CompressionStats { get; private set; }
        public Dictionary<string, string> ErrorLog { get; private set; }
    }
}
