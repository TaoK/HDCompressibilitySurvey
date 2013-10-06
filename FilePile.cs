using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HDSurvey
{
    class FilePile
    {
        public long TotalFileSize { get; private set; }
        public long TotalFileSizeDynamic
        {
            get
            {
                return files.Aggregate((long)0, (soFar, file) => soFar + file.Length);
            }
        }

        private List<FileInfo> files = new List<FileInfo>();
        //TODO: clean up, figure out who would need this when for what
        public IList<FileInfo> Files
        {
            get
            {
                return files;
            }
        }

        //TODO: determine whether we would want to add validation of extension... seems pointless waste of resources...?
        public void AddFile(FileInfo file)
        {
            TotalFileSize += file.Length;
            files.Add(file);
        }
    }
}
