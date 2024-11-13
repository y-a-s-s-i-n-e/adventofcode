namespace AdventOfCode._2015.Day_1;

public static class Core
{
    public static int Part1(string input)
    {
        var floor = 0;
        foreach (var c in input)
        {
            floor += c switch
            {
                '(' => 1,
                ')' => -1,
                _ => 0
            };
        }

        return floor;
    }

    public static int Part2(string input)
    {
        var floor = 0;
        var i = 0;
        foreach (var c in input)
        {
            floor += c switch
            {
                '(' => 1,
                ')' => -1,
                _ => 0
            };

            i++;

            if (floor == -1)
            {
                break;
            }
        }
        
        return i;
    }
}