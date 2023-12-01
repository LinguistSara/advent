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
            var first = numbers[0]; /*det �r en char f�r att det �r ett tecken fr�n en str�ng*/
            var last = numbers[^1];
            //var l = numbers.Last(); samma som den ovan
            //var number = first.ToString() + last.ToString(); g�r samma som den under
            var num = $"{first}{last}"; //string-interpolering - anv�nda variabler inne i en str�ng       
            var x = int.Parse(num); //g�r om num(som �r en str�ng) till int
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

