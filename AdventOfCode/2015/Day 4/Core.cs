using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2015.Day_4;

public static class Core
{
    public static int Part1(string input)
    {
        var hashedInput = "";
        var counter = 0;
        
        while (!hashedInput.StartsWith("00000"))
        {
            counter++;
            hashedInput = CalculateMd5Hash(input + counter);
        }
        
        return counter;
    }
    
    public static int Part2(string input)
    {
        var hashedInput = "";
        var counter = 0;
        
        while (!hashedInput.StartsWith("000000"))
        {
            counter++;
            hashedInput = CalculateMd5Hash(input + counter);
        }
        
        return counter;
    }
    
    private static string CalculateMd5Hash(string input)
    {
        using var md5 = MD5.Create();
        
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = md5.ComputeHash(inputBytes);
        var sb = new StringBuilder();
        
        foreach (var b in hashBytes)
        {
            sb.Append(b.ToString("x2"));
        }

        return sb.ToString();
    }
}