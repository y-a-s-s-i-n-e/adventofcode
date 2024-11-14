using System.Text.RegularExpressions;

namespace AdventOfCode._2015.Day_6;

public static class Core
{
    public static int Part1(string input)
    {
        const string pattern = @"\b(\d+),(\d+)\b.*\b(\d+),(\d+)\b";

        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var grid = new bool[1000, 1000];

        foreach (var line in lines)
        {
            var match = Regex.Match(line, pattern);
            
            if (match.Success)
            {
                var x1 = int.Parse(match.Groups[1].Value);
                var y1 = int.Parse(match.Groups[2].Value);
                var x2 = int.Parse(match.Groups[3].Value);
                var y2 = int.Parse(match.Groups[4].Value);

                if (line.Contains("turn on"))
                {
                    for (var x = x1; x <= x2; x++)
                    {
                        for (var y = y1; y <= y2; y++)
                        {
                            grid[x, y] = true;
                        }
                    }
                }
                else if (line.Contains("turn off"))
                {
                    for (var x = x1; x <= x2; x++)
                    {
                        for (var y = y1; y <= y2; y++)
                        {
                            grid[x, y] = false;
                        }
                    }
                }
                else if (line.Contains("toggle"))
                {
                    for (var x = x1; x <= x2; x++)
                    {
                        for (var y = y1; y <= y2; y++)
                        {
                            grid[x, y] = !grid[x, y];
                        }
                    }
                }
            }
        }
        
        return grid.Cast<bool>().Count(value => value);
    }
    
    public static int Part2(string input)
    {
        const string pattern = @"\b(\d+),(\d+)\b.*\b(\d+),(\d+)\b";

        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var grid = new int[1000, 1000];

        foreach (var line in lines)
        {
            var match = Regex.Match(line, pattern);
            
            if (match.Success)
            {
                var x1 = int.Parse(match.Groups[1].Value);
                var y1 = int.Parse(match.Groups[2].Value);
                var x2 = int.Parse(match.Groups[3].Value);
                var y2 = int.Parse(match.Groups[4].Value);

                if (line.Contains("turn on"))
                {
                    for (var x = x1; x <= x2; x++)
                    {
                        for (var y = y1; y <= y2; y++)
                        {
                            grid[x, y] += 1;
                        }
                    }
                }
                else if (line.Contains("turn off"))
                {
                    for (var x = x1; x <= x2; x++)
                    {
                        for (var y = y1; y <= y2; y++)
                        {
                            if (grid[x, y] > 0)
                            {
                                grid[x, y] -= 1;
                            }
                        }
                    }
                }
                else if (line.Contains("toggle"))
                {
                    for (var x = x1; x <= x2; x++)
                    {
                        for (var y = y1; y <= y2; y++)
                        {
                            grid[x, y] += 2;
                        }
                    }
                }
            }
        }
        
        var brightness = 0;
        for (var i = 0; i < grid.GetLength(0); i++) 
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                brightness += grid[i, j];
            }
        }

        return brightness;
    }
}