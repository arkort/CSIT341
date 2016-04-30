using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Test
{
    public static void Main()
    {
        Dictionary<string, int> stat = new Dictionary<string, int>();

        string infile = "input.txt";
        string outfile = "output.txt";

        string[] qwe = Directory.GetFiles(File.ReadAllText(infile), ".", SearchOption.AllDirectories);
        foreach (string fullname in qwe)
        {
            string ext = Path.GetExtension(fullname);
            int Count = 0;
            if (stat.TryGetValue(ext, out Count))
            { 
                stat[ext] = Count+1; 
            }
            else stat.Add(ext, 1);           

        }
        stat = stat.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        using (StreamWriter output = new StreamWriter(outfile))
        {
            foreach (var elem in stat)
            {
                output.WriteLine("{0}#{1}#{2}", elem.Key, elem.Value.ToString(), (100.0 * elem.Value / qwe.Length).ToString("0.0"));
            }
        }
    }
}