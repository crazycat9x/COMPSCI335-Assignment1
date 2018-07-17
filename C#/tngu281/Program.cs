using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace tngu281
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(args[0]))
            {
                Regex
                    .Split(sr.ReadToEnd().ToUpper(), @"[^A-Z]+")
                    .Where(word => word.Length != 0)
                    .GroupBy(word => word)
                    .OrderBy(word => -word.Count())
                    .Take(int.Parse(args[1]))
                    .ToList()
                    .ForEach(word => Console.WriteLine($"{word.Key} {word.Count()}"));
            }
        }
    }
}