using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 
    Function Description

    Complete the jumpingOnClouds function in the editor below. 
    It should return the minimum number of jumps required, as an integer.

    jumpingOnClouds has the following parameter(s):
        c: an array of binary integers

    Input Format
        The first line contains an integer n, the total number of clouds. 
        The second line contains n space-separated binary integers describing clouds c[i] where 0 <= i < n.

    Constraints
        2 <= n <= 100
        c[i] = 0 or 1
        c[0] = c[n-1] = 0

    Output Format
        Print the minimum number of jumps needed to win the game.

        Sample Input 0
            7
            0 0 1 0 0 1 0
        Sample Output 0
            4
        Explanation 0: 
            Emma must avoid c[2] and c[5]. She can win the game with a minimum of 4 jumps:


        Sample Input 1
            6
            0 0 0 0 1 0
        Sample Output 1
            3
 */

namespace JumpingOnClouds
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter("output.txt", false);
            int n = Convert.ToInt32(Console.ReadLine());
            textWriter.WriteLine("no. of clouds : " + n);
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            textWriter.WriteLine("cloud sequence : " + string.Join(",", ar));
            textWriter.WriteLine("no. of jumps : " + jumpingOnClouds(ar));
            textWriter.Flush();
            textWriter.Close();
        }

        // Complete the jumpingOnClouds function below.
        static int jumpingOnClouds(int[] c)
        {
            if (c[0] > 0 || c[c.Length - 1] > 0)
                return -1;
            int hop = 0;
            for (int x = 0; x < c.Length;)
            {
                for(int y = x + 1; ;)
                {
                    if(y >= c.Length)
                    {
                        x += 1;
                        break;
                    }
                    if((y + 1 < c.Length) && c[y+1] == 0)
                    {
                        hop++;
                        x += 2;
                        break;
                    } else if (c[y] == 0)
                    {
                        hop++;
                        x += 1;
                        break;
                    } else
                    {
                        return -1;
                    }
                }
            }
            return hop;
        }
    }
}
