using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length != 2) throw new Exception("wrong number of arguments");
            if (!Regex.IsMatch(args[1], @"^\+?(0|[1-9]\d*)$")) throw new Exception("k is not a valid number");
            if (!Regex.IsMatch(args[0], @".txt$")) throw new Exception($"{args[0]} is not a valid txt file");
            Regex
                .Matches(File.ReadAllText(args[0]).ToUpper(), @"[A-Z]+")
                .Cast<Match>()
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
