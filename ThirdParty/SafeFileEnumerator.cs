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
            if (path.EndsWith(" "))
                throw new NotSupportedException(string.Format("Directory '{0}' ends with a space, which is not supported by 'System.IO' classes (and many other parts of Windows). Please rename the directory (eg at the command using the 'rename' command with the 8.3 name; explorer does not allow for this) before attempting to iterate this path.", path));

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
