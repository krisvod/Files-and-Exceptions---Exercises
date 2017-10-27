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
            var Emails = new Dictionary<string, string>();
            string email;
            string substring;
            string[] name = File.ReadAllLines("input.txt");
            int j = 1;
            for (int i = 0; i < name.Length - 1; i += 2)
            {
                email = name[j];
                if (!Emails.ContainsKey(name[i]))
                {
                    Emails.Add(name[i], email);
                }
                j += 2;
                if (name[i] == "stop")
                    break;
            }
            foreach (var named in Emails.Keys)
            {
                substring = Emails[named].Substring(Emails[named].Length - 2);
                if (substring == "us" || substring == "uk") ;
                else
                    File.AppendAllText("output.txt", $"{named} -> {Emails[named]}" + Environment.NewLine);
            }
        }
    }
}
