using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.IO;


/*
 * Function Description

    Complete the sockMerchant function in the editor below. 
    It must return an integer representing the number of matching pairs of socks that are available.

    sockMerchant has the following parameter(s):

        n: the number of socks in the pile
        ar: the colors of each sock

    Input Format

        The first line contains an integer , the number of socks represented in . 
        The second line contains  space-separated integers describing the colors  of the socks in the pile.

    Constraints
        1 <= n <= 100
        1 <= ar[i] <= 100 where 0 <= i < n

    Output Format
        Return the total number of matching pairs of socks that John can sell.

    Sample Input
        9
        10 20 20 10 10 30 50 10 20

    Sample Output
        3
 */
namespace SockMerchant
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter("output.txt", false);
            int n = Convert.ToInt32(Console.ReadLine());
            textWriter.WriteLine("no. of socks : " + n);
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            textWriter.WriteLine("socks are : " + string.Join(",", ar));
            int result = sockMerchant(n, ar);
            textWriter.WriteLine("no. of pairs : " + result);
            textWriter.Flush();
            textWriter.Close();
        }

        // Complete the sockMerchant function below.
        static int sockMerchant(int n, int[] ar)
        {
            int nPairs = 0;
            ConcurrentDictionary<int, int> keyValuePairs = new ConcurrentDictionary<int, int>();
            if (n >= 1 && n <= 100)
            {
                for (int i = 0; i >= 0 && n > i; i++)
                {
                    keyValuePairs.AddOrUpdate(ar[i], 1, (k, v) => v + 1);
                }
            }
            foreach (int i in keyValuePairs.Values)
            {
                if(i > 1)
                {
                    nPairs += i / 2;
                }
            }
            return nPairs;
        }
    }
}
