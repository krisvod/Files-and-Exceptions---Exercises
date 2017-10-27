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
            char[] arr = new char[26];
            for (int i = 0; i < 26; i++)
                arr[i] = (char)('a' + i);
            string word = File.ReadAllText("input.txt");
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (arr[j] == word[i])
                    {
                        File.AppendAllText("output.txt", $"{word[i]} -> {j}" + Environment.NewLine);
                    }
                }
            }
        }
    }
}
