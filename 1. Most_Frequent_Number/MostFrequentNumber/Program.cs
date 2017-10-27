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
            int[] count = new int[65536];
            int best = 0;
            foreach (int num in nums)
            {
                count[num]++;
            }
            best = count.Max();
            for (int i = 0; i < nums.Length; i++)
            {
                if (count[nums[i]] == best)
                {
                    File.WriteAllText("output.txt", Convert.ToString(nums[i]));
                    return;
                }
            }
        }
    }
}
