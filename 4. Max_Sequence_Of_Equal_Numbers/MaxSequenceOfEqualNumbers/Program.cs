using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication12
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            int[] nums = input
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int count = 1;
            int highcount = 1;
            int current = 0;
            int best = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    count++;
                    if (highcount < count)
                    {
                        highcount = count;
                        best = current;
                    }
                }
                else
                {
                    current = i;
                    count = 1;
                }
            }
            for (int i = best; i < best + highcount; i++)
                File.AppendAllText("output.txt", nums[i] + " ");
        }
    }
}
