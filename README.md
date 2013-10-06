
## HD Compressibility Survey Tool

This is a .Net 3.5 WinForms C# program to examine the contents of a hard drive by file extension 
and sample the compressibility of data by file extension. 

The intent of this process is to help identify what types of files should generally not be 
attempted to be compressed in a backup process (specifically, this project was inspired by
the "default_compressed_extensions.txt" extension list included with the latest test download 
of Duplicati, an open-source .Net backup system).


### Methodology

* Find all files in a target path, recursively iterating through directories/folders
** While iterating through the folders, collect filenames and sizes, collecting/aggregating by extension
* For each extension (except those known compressed ones, if they are to be skipped):
** Determine how many files to test compression on - 10%, or up to 100 files if that number is less (even if that is all files found)
** Pick that number of files randomly from those found earlier
** For each file, compress up to 1MB of data using LZMA2 compression (default settings of the "managed-lzma" library), and determine how many bytes of data the compressed result is.
** Store the compresion ratio and average for the extension
* During the process, update/display the status in the UI every once in a while
** Allowing exploration of sampled files
* When done, allow export of accumulated data into an excel workbook


### Known Issues / Next Steps

There are numerous open issues and possible enhancements I'd like to look at in the coming 
days/weeks/months, although the project has reached a level of usability sufficient for placing
online and using on my different computers, so I'm not sure I will be working up the will to 
tackle any of these anytime soon:

* Allow for editing the "Known Compressed" file list in the UI, and saving the result back to file
* Displaying an "Estimated Compression Time" column, and an "Estimated Space Savings" column in
    the UI or export, to make it easier to estimate the cost to benefit ratio of any given
    compression exception.
* Excluding Junction Points (optionally?) from the directory walking process, to help avoid 
    counting certain files twice.
* Deciding what open-source license to apply to this project, and confirming that all third-
    party code used is "OK" with the given license.
* Cleanup of async data-collection process into a reusable "Collector" class rather than coded 
    in the UI class directly
* Better orgnization/grouping in UI, and disabling things that cannot be effectively changed 
    during the data collection process, for visual clarity / to avoid confusion.
* Allowing for editing the "target percent of files" for compressibility testing - currently fixed at 10%
* Add some sort of "submit to the mothership" functionality so that people could contribute their local stats and we could build up a "fair" picture across many systems


### License / Third-party Code

I have not yet decided on what license to use for this code; in the meantime, I guess the default applies, i.e. copyright belongs to me.

I have used a couple of third-party libraries:
* managed-lzma (MIT license)
* EPPlus (LGPL license)

There is also a number of code snippets that I came across in different places online, to
solve "known problems" - these need to to be collected and evaluated in case there are any
licensing consequences.
