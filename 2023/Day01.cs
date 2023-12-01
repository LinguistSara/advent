using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent.y2023;

[AoC(2023)]
public class Day01 : Day
{
    public Day01() : base(1, 2023)
    {

    }

    public override object Part1(List<string> input)
    {
        var calibrationList = new List<int>();
        foreach (var row in input)
        {
            var numbers = new List<char>();
            foreach (var c in row)
            {
                if (char.IsDigit(c)) 
                {  
                    numbers.Add(c);
                }
            }
            var first = numbers[0]; /*det är en char för att det är ett tecken från en sträng*/
            var last = numbers[^1];
            //var l = numbers.Last(); samma som den ovan
            //var number = first.ToString() + last.ToString(); gör samma som den under
            var num = $"{first}{last}"; //string-interpolering - använda variabler inne i en sträng       
            var x = int.Parse(num); //gör om num(som är en sträng) till int
            calibrationList.Add(x);
        }

        //var summa = calibrationList.Sum();
        var summa = 0;
        foreach (var x in calibrationList)
        {
            summa += x;
        }

        return summa;
    }
    public override object Part2(List<string> input)
    {
        return 0;
    }
}

