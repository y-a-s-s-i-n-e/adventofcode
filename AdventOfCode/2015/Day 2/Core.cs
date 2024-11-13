namespace AdventOfCode._2015.Day_2;

public static class Core
{
    public static int Part1(string input)
    {
        var totalAreas = 0;
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var line in lines)
        {
            var dimensions = line.Split('x').Select(int.Parse).ToArray();
            var l = dimensions[0];
            var w = dimensions[1];
            var h = dimensions[2];
            var smallestSideArea = new[] { l*w, w*h, h*l }.Min();

            totalAreas = totalAreas + ((2 * l * w) + (2*w*h) + (2*h*l)) + smallestSideArea;
        }

        return totalAreas;
    }
    
    public static int Part2(string input)
    {
        var total = 0;
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var line in lines)
        {
            var dimensions = line.Split('x').Select(int.Parse).ToArray();
            var l = dimensions[0];
            var w = dimensions[1];
            var h = dimensions[2];
            var smallestPerimeter = new[] { 2*l + 2*w, 2*w + 2*h, 2*l + 2*h }.Min();
            
            total = total + (l*w*h) + smallestPerimeter;
        }

        return total;
    }
}