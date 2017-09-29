using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using static System.Linq.Enumerable;

namespace PlmonFuncTestNunit.Helpers
{
    public static class Randomizer
    {
        public static string String(int length, IEnumerable<char> characterSet)
        {
            var characterArray = characterSet.Distinct().ToArray();

            var bytes = new byte[length * 8];

            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(bytes);
                var result = new char[length];
                for (int i = 0; i < length; i++)
                {
                    ulong value = BitConverter.ToUInt64(bytes, i * 8);
                    result[i] = characterArray[value % (uint)characterArray.Length];
                }

                return new string(result);
            }
        }

        public static string String(int length)
        {
            //20-47: " !"#$%&'()*+,-./"
            //58-64: ":;<=>?@"
            //91-96: "[\]^_`"
            //123-126: "{|}~"
            //48-57: "1234567890"
            //65-90: "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            //97-122: "abcdefghijklmnopqrstuvwxyz"
            //1040-1071: "А-Я"
            //1072-1103: "а-я"

            var otherChars = Range(20, 28)
                            .Union(Range(58, 7))
                            .Union(Range(91, 6))
                            .Union(Range(123, 4));

            var digitChars = Range(48, 10);
            var cyrillicChars = Range(1040, 32);
            var latinChars = Range(65, 26)
                            .Union(Range(97, 26));


            var listCharCode = new List<int>();
            //listCharCode.AddRange(otherChars);
            listCharCode.AddRange(digitChars);
            listCharCode.AddRange(latinChars);
            //listCharCode.AddRange(cyrillicChars);

            var characterSet = listCharCode.Select(x => (char)x);
            return String(length, characterSet);
        }

        public static string Decimal(int precision, int scale, bool positive)
        {
            if (!(precision >= 1 && precision <= 28))
                throw new ArgumentOutOfRangeException(nameof(precision), precision, "Precision must be between 1 and 28.");
            if (!(scale >= 0 && scale <= precision))
                throw new ArgumentOutOfRangeException(nameof(scale), precision, "Scale must be between 0 and precision.");

            var rnd = new Random();

            decimal d = 0m;
            for (int i = 0; i < precision; i++)
            {
                int r = rnd.Next(0, 10);
                d = d * 10m + r;
            }
            for (int s = 0; s < scale; s++)
            {
                d /= 10m;
            }
            string format = "F" + scale;
            return d.ToString(format);
        }

        public static int Number(int min, int max)
        {
            var rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}
