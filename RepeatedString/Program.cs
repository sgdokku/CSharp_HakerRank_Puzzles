using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace RepeatedString
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter("output.txt", false);
            string s = Console.ReadLine();
            long n = Convert.ToInt64(Console.ReadLine());
            long result = repeatedString(s, n);
            textWriter.WriteLine(result);
            textWriter.Flush();
            textWriter.Close();
        }

        // Complete the repeatedString function below.
        static long repeatedString(string s, long n)
        {
            long iOccurences = 0;
            if (String.IsNullOrEmpty(s) || s.Length > 100 || !s.Contains('a'))
                return iOccurences;
            if (n < 1 || n > Math.Floor(Math.Pow(10, 12)))
                return iOccurences;
            long sLen = s.Length;
            if (sLen == 1)
                return n;
            int strSingleOccurence = Regex.Matches(s, "a").Count;
            if (n == 1)
                return strSingleOccurence;
            long strQuo = n / sLen;
            long strRem = n % sLen;
            iOccurences = (strSingleOccurence * strQuo) + (strRem > 0 ? Regex.Matches(s.Substring(0, (int) strRem), "a").Count : 0);
            return iOccurences;
        }
    }
}
