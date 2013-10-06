using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HDSurvey
{
    class FileCompressionTester : IDisposable
    {
        private const int DEFAULT_THREAD_COUNT = 2;
        private const int DEFAULT_MAX_TEST_LENGTH = 0x100000;

        private Random _localRandom;
        private ManagedLzma.LZMA.Master.SevenZip.ArchiveWriter.Lzma2Encoder _lzma2Encoder;
        private int _maxTestLength;

        public FileCompressionTester() : this(DEFAULT_MAX_TEST_LENGTH) { }

        public FileCompressionTester(int MaxTestLength)
        {
            _maxTestLength = MaxTestLength;
            _localRandom = new Random();
            _lzma2Encoder = new ManagedLzma.LZMA.Master.SevenZip.ArchiveWriter.Lzma2Encoder(DEFAULT_THREAD_COUNT);
        }

        public double? TestCompressionRatio(string file)
        {
            int dummy1 = 0;
            int dummy2 = 0;
            return TestCompressionRatio(file, out dummy1, out dummy2);
        }

        public double? TestCompressionRatio(string file, out int testedByteCount, out int outputByteCount)
        {
            byte[] data;

            try
            {
                using (var test = File.OpenRead(file))
                {
                    if (test.Length > _maxTestLength)
                    {
                        //grab the max length from some random spot in the file
                        data = new byte[_maxTestLength];
                        test.Position = _localRandom.NextLong(0, test.Length - _maxTestLength); ;
                        test.Read(data, 0, _maxTestLength);
                    }
                    else
                    {
                        //grab full contents
                        data = new byte[test.Length];
                        test.Read(data, 0, (int)test.Length);
                    }
                }

                testedByteCount = data.Length;

                using (var rawArchiveStream = new MemoryStream())
                {
                    var m_writer = new ManagedLzma.LZMA.Master.SevenZip.ArchiveWriter(rawArchiveStream);
                    m_writer.ConnectEncoder(_lzma2Encoder);

                    using (var encoderStream = _lzma2Encoder.BeginWriteFile(new ArchiveWriterEntry { Name = file }))
                    {
                        encoderStream.Write(data, 0, data.Length);
                    }
                    m_writer.WriteFinalHeader();
                    m_writer.DisconnectEncoder();
                    outputByteCount = (int)m_writer.WrittenSize; //this should never get to "long" dimensions...
                }

                return (testedByteCount - outputByteCount) * 1.0 / testedByteCount;
            }
            catch (UnauthorizedAccessException)
            {
                //exact error doesn't really matter - just important to know there was an issue
                testedByteCount = 0;
                outputByteCount = 0;
                return null;
            }
            catch (IOException)
            {
                //exact error doesn't really matter - just important to know there was an issue
                testedByteCount = 0;
                outputByteCount = 0;
                return null;
            }
        }

        private class ArchiveWriterEntry : ManagedLzma.LZMA.Master.SevenZip.IArchiveWriterEntry
        {
            public FileAttributes? Attributes { get; set; }
            public DateTime? CreationTime { get; set; }
            public DateTime? LastAccessTime { get; set; }
            public DateTime? LastWriteTime { get; set; }
            public string Name { get; set; }
        }

        public void Dispose()
        {
            //TODO: actually implement disposal of the lzma encoder instance...
        }
    }
}
