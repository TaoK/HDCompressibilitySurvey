using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace HDSurvey
{
    //taken shamelessly (and with minor modifications) from http://stackoverflow.com/a/13954763/74296
    // -> short enough to not need to worry about copyright??
    //TODO: confirm copyright.
    public static class SafeFileEnumerator
    {

        public static IEnumerable<string> EnumerateDirectories(string parentDirectory, string searchPattern, SearchOption searchOpt)
        {
            try
            {
                var directories = Enumerable.Empty<string>();
                if (searchOpt == SearchOption.AllDirectories)
                {
                    directories = Directory.EnumerateDirectories(parentDirectory)
                        .SelectMany(x => EnumerateDirectories(x, searchPattern, searchOpt));
                }
                return directories.Concat(Directory.EnumerateDirectories(parentDirectory, searchPattern));
            }
            catch (UnauthorizedAccessException)
            {
                return Enumerable.Empty<string>();
            }
        }

        public static IEnumerable<FileInfo> EnumerateFiles(string path, string searchPattern, SearchOption searchOpt)
        {
            try
            {
                var dirFiles = Enumerable.Empty<FileInfo>();
                if (searchOpt == SearchOption.AllDirectories)
                {
                    dirFiles = Directory.EnumerateDirectories(path)
                                        .SelectMany(x => EnumerateFiles(x, searchPattern, searchOpt));
                }
                return dirFiles.Concat(new DirectoryInfo(path).EnumerateFiles(searchPattern));
            }
            catch (UnauthorizedAccessException)
            {
                return Enumerable.Empty<FileInfo>();
            }
        }
    }
}
