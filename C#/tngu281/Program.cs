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
            try
            {
                if (args.Length != 4) throw new Exception("Parameter cannot be null");
                if (!Regex.IsMatch(args[1], @"^\+?(0|[1-9]\d*)$")) throw new Exception("k is not a valid number");
                if (!Regex.IsMatch(args[0], @"/.txt$/")) throw new Exception($"{args[0]} is not a valid txt file");
                Regex
                    .Matches(File.ReadAllText(args[0]).ToUpper(), @"[A-Z]+")
                    .GroupBy(word => word.Value)
                    .OrderByDescending(word => word.Count())
                    .ThenBy(word => word.Key)
                    .Take(int.Parse(args[1]))
                    .ToList()
                    .ForEach(word => Console.WriteLine($"{word.Key} {word.Count()}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"*** Error: {ex.Message}");
                Environment.ExitCode = 1;
            }
        }
    }
}