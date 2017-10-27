using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Equal_Sums
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
            for (int output = 0; output < nums.Length; output++) //index
            {
                int leftsum = 0;
                int rightsum = 0;
                for (int i = 0; i < output; i++) //left sum loop
                {
                    leftsum += nums[i];
                }
                for (int j = output + 1; j < nums.Length; j++) //right sum loop
                {
                    rightsum += nums[j];
                }
                if (leftsum == rightsum)
                {
                    File.WriteAllText("output.txt", output.ToString());
                    return;
                }
            }
            File.WriteAllText("output.txt", "no");
        }
    }
}
