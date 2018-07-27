using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        int k = 3;
        try
        {
            if (args.Length == 2)
            {
                if (!Regex.IsMatch(args[1], @"^\+?([0-9]\d*)$")) throw new Exception($"{args[1]} is not a valid number");
                k = int.Parse(args[1]);
            }
            else if (args.Length != 1)
            {
                throw new Exception("wrong number of arguments");
            }
            Regex
                .Matches(File.ReadAllText(args[0]).ToUpper(), @"[A-Z]+")
                .Cast<Match>()
                .GroupBy(word => word.Value)
                .OrderByDescending(word => word.Count())
                .ThenBy(word => word.Key)
                .Take(k)
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
