using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace HDSurvey
{
    class FileDataCollector : BackgroundWorker
    {
        //TODO: easier to do on GUI for now, but I was hoping to be a little more generic later...

        public bool IsStarted { get; private set; }
        public bool IsAborted { get; private set; }
        public bool IsCompleted { get; private set; }

        public string SearchPath { get; set; }
        public FileExtensionDataCollection Data { get; private set; }

        public void CollectData() 
        {
            throw new NotImplementedException();

            //TODO: move background work stuff from background worker on main form to here.
            /*
            Data = new FileExtensionDataCollection(StringComparer.OrdinalIgnoreCase);
            var baseFolder = new DirectoryInfo(SearchPath);
            long fileCounter = 0;

            foreach (var file in baseFolder.EnumerateFiles("*.*", SearchOption.AllDirectories))
            {
                Data.AddFile(file);
                fileCounter++;

                if (fileCounter % 1000 == 0)
                    fileCounter = fileCounter;
            }
            */
        }


    }
}
