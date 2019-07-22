using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


namespace CountingValley
{
    class Program
    {
        // Complete the countingValleys function below.
        static int countingValleys(int n, string s)
        {
            int iLevel = 0, iValley = 0;
            if (n <= 2 || n > Math.Pow(10, 6))
                return iLevel;
            HashSet<char> _legalChars = new HashSet<char>("UD".ToCharArray());
            if (String.IsNullOrEmpty(s) || s.Except(_legalChars).Any())
                return iLevel;
            if (n != s.Length)
                return iLevel;
            foreach(char c in s)
            {
                if (c == 'D')
                {
                    if (iLevel == 0)
                    {
                         iValley++;
                    }
                    iLevel--;
                }
                else
                    iLevel++;
            }
            return iValley;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter("output.txt", false);
            int n = Convert.ToInt32(Console.ReadLine());
            textWriter.WriteLine("no of steps : " + n);
            string s = Console.ReadLine();
            textWriter.WriteLine("trek path : " + s);
            int result = countingValleys(n, s);
            textWriter.WriteLine("no of valleys : " + result);
            textWriter.Flush();
            textWriter.Close();
        }
    }
}
