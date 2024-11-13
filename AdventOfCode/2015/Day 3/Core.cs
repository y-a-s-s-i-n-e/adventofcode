namespace AdventOfCode._2015.Day_3;

public static class Core
{
    public static int Part1(string input)
    {
        var x = 0;
        var y = 0;
        
        var coordinates = new HashSet<(int, int)> { (x, y) };
        var visitedHouses = 1;

        foreach (var c in input)
        {
            x = c switch
            {
                '<' => x - 1,
                '>' => x + 1,
                _ => x
            };
            
            y = c switch
            {
                '^' => y + 1,
                'v' => y - 1,
                _ => y
            };
            
            if (coordinates.Add((x, y)))
            {
                visitedHouses++;
            }
        }

        return visitedHouses;
    }
    
    public static int Part2(string input)
    {
        var santaX = 0;
        var santaY = 0;
        var robotSantaX = 0;
        var robotSantaY = 0;

        const string santa = "santa";
        const string robotSanta = "robotSanta";
        
        var coordinates = new HashSet<(int, int)> { (0, 0) };
        var visitedHouses = 1;
        
        var visitor = santa;

        foreach (var c in input)
        {
            if (visitor == santa)
            {
                santaX = c switch
                {
                    '<' => santaX - 1,
                    '>' => santaX + 1,
                    _ => santaX
                };
            
                santaY = c switch
                {
                    '^' => santaY + 1,
                    'v' => santaY - 1,
                    _ => santaY
                };
                
                if (coordinates.Add((santaX, santaY)))
                {
                    visitedHouses++;
                }
            }
            else
            {
                robotSantaX = c switch
                {
                    '<' => robotSantaX - 1,
                    '>' => robotSantaX + 1,
                    _ => robotSantaX
                };
            
                robotSantaY = c switch
                {
                    '^' => robotSantaY + 1,
                    'v' => robotSantaY - 1,
                    _ => robotSantaY
                };
                
                if (coordinates.Add((robotSantaX, robotSantaY)))
                {
                    visitedHouses++;
                }
            }
            
            visitor = visitor == santa ? robotSanta : santa;
        }

        return visitedHouses;
    }
}