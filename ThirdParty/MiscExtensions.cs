using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HDSurvey
{
    //Taken from http://stackoverflow.com/a/6651656/74296
    //TODO: think about copyright issues once again...
    public static class RandomExtensions
    {
        public static long NextLong(this Random rnd)
        {
            byte[] buffer = new byte[8];
            rnd.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

        public static long NextLong(this Random rnd, long min, long max)
        {
            EnsureMinLEQMax(ref min, ref max);
            long numbersInRange = unchecked(max - min + 1);
            if (numbersInRange < 0)
                throw new ArgumentException("Size of range between min and max must be less than or equal to Int64.MaxValue");

            long randomOffset = NextLong(rnd);
            if (IsModuloBiased(randomOffset, numbersInRange))
                return NextLong(rnd, min, max); // Try again
            else
                return min + PositiveModuloOrZero(randomOffset, numbersInRange);
        }

        static bool IsModuloBiased(long randomOffset, long numbersInRange)
        {
            long greatestCompleteRange = numbersInRange * (long.MaxValue / numbersInRange);
            return randomOffset > greatestCompleteRange;
        }

        static long PositiveModuloOrZero(long dividend, long divisor)
        {
            long mod;
            Math.DivRem(dividend, divisor, out mod);
            if (mod < 0)
                mod += divisor;
            return mod;
        }

        static void EnsureMinLEQMax(ref long min, ref long max)
        {
            if (min <= max)
                return;
            long temp = min;
            min = max;
            max = temp;
        }
    }

    public static class TimeSpanExtensions
    {
        public static string DisplaySecs(this TimeSpan timeDiff)
        {
            return string.Format("{0:0.0} sec", timeDiff.TotalSeconds);
        }
    }

    public static class NumberExtensions
    {
        //From http://www.extensionmethod.net/csharp/string/formatsize
        // modified to add places beyond "byte".
        public static string FormatFileSize(this long fileSize)
        {
            string[] suffix = { "bytes", "KB", "MB", "GB" };
            long j = 0;
            double localSize = fileSize;

            while (localSize > 1024 && j < 4)
            {
                localSize = localSize / 1024;
                j++;
            }

            //no elegant way of avoiding decimals on the raw value...
            if (j > 0)
                return string.Format("{0:##.##} {1}", localSize, suffix[j]);
            else
                return string.Format("{0} {1}", fileSize, suffix[j]);
        }
    }
}
