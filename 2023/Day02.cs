using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent.y2023;

[AoC(2023)]
public class Day02 : Day
{
    public Day02() : base(2, 2023)
    {

    }

    public override object Part1(List<string> input)
    {
        var sum = 0;
        foreach (var row in input)
        {
            var idAndData = row.Split(":");
            var id = int.Parse(idAndData[0].Replace("Game ",""));
            //var id = int.Parse(idAndData[0][5..]); börja på 5 och fortsätt till slutet
            var red = GetMaxValueForColour("red", idAndData[1]);
            var green = GetMaxValueForColour("green", idAndData[1]);
            var blue = GetMaxValueForColour("blue", idAndData[1]);
            if (red <= 12 && green <= 13 && blue <= 14)
            {
                sum += id;
            }

        }
        return sum;
    }

    

    public override object Part2(List<string> input)
    {
        var sum = 0;
        foreach (var row in input)
        {
            var idAndData = row.Split(":");
            var red = GetMaxValueForColour("red", idAndData[1]);
            var green = GetMaxValueForColour("green", idAndData[1]);
            var blue = GetMaxValueForColour("blue", idAndData[1]);
            sum += red * green * blue;
        }
        return sum;
    }

    private int GetMaxValueForColour(string colour, string data)
    {
        var c = Regex.Matches(data, @$"\d+ {colour}");
        var max = 0;
        foreach (Match item in c)
        {
            var value = int.Parse(item.Value.Replace($" {colour}", ""));
            if (value > max)
            {
                max = value;
            }
        }
        return max;
    }

}

