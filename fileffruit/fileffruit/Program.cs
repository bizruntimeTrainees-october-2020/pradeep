using System;
using System.Collections.Generic;
using System.IO;

namespace fileffruit
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                TextWriter tw = new StreamWriter(@"E:\crayon.txt", true);
    
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           
            string filepath = @"E:\crayon.txt";
            List<string> lines = new List<string>();

            lines.Add("oragnge");
            lines.Add("blue");
            lines.Add("green");
            lines.Add("yellow");
            File.WriteAllLines(filepath, lines);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.ReadLine();
            
        }
    }
}
