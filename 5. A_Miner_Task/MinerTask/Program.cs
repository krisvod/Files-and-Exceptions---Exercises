using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("output.txt", "");
            var Resources = new Dictionary<string, int>();
            int value;
            string[] input = File.ReadAllLines("input.txt");
            int j = 1;
            for (int i = 0; i < input.Length - 1; i+=2)
            {
                value = int.Parse(input[j]);
                if (!Resources.ContainsKey(input[i]))
                {
                    Resources.Add(input[i], 0);
                }
                Resources[input[i]] += value;
                j += 2;
                if (input[i] == "stop")
                    break;
            }
            foreach (var resource in Resources.Keys)
                File.AppendAllText("output.txt", $"{resource} -> {Resources[resource]}" + Environment.NewLine);
        }
    }
}
