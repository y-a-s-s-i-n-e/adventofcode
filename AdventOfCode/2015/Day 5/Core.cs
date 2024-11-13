namespace AdventOfCode._2015.Day_5;

public static class Core
{
    public static int Part1(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var niceCount = 0;

        foreach (var line in lines)
        {
            if (IsNicePart1(line))
            {
                niceCount++;
            }
        }
        
        return niceCount;
    }
    
    public static int Part2(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var niceCount = 0;

        foreach (var line in lines)
        {
            if (IsNicePart2(line))
            {
                niceCount++;
            }
        }
        
        return niceCount;
    }
    
    
    private static bool IsNicePart1(string line)
    {
        var counterVowels = 0;
        var previousChar = "";
        var condition1 = false;

        foreach (var c in line)
        {
            if (c is 'a' or 'e' or 'i' or 'o' or 'u')
            {
                counterVowels++;
            }
            
            var currentChar = c.ToString();
            
            if (currentChar == previousChar)
            {
                condition1 = true;
            }
            
            previousChar = c.ToString();
        }
        
        return counterVowels >= 3 && condition1 && !line.Contains("ab") && !line.Contains("cd") && !line.Contains("pq") && !line.Contains("xy");
    }

    private static bool IsNicePart2(string line)
    {
        var i = 0;
        var condition1 = false;
        
        while (i < line.Length - 1)
        {
            var doubleChar = line[i] + line[i + 1].ToString();
            var lineToValidate = line.Substring(i + 2);  
            
            if (lineToValidate.Contains(doubleChar))
            {
                condition1 = true;
            }
            i++;
        }
        
        var y = 0;
        var condition2 = false;
        
        foreach (var c in line)
        {
            if (y + 2 < line.Length && c == line[y + 2])
            {
                condition2 = true;
            }
            y++;
        }
        
        return condition1 && condition2;
    }
}