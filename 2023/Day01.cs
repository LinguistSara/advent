using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
            var first = numbers.Any() ? numbers[0] : '0';
            var last = numbers.Any() ? numbers[^1] : '0';
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
        var calibrationList = new List<int>();
        foreach (var row in input)
        {
            var pattern = @"\d|one|two|three|four|five|six|seven|eight|nine";
            var first = Regex.Match(row, pattern).Value;
            var last = Regex.Match(row, pattern, RegexOptions.RightToLeft).Value;
            var num = (GetNumber(first)*10) + GetNumber(last);

            using (var fs = new FileStream("result2.csv", FileMode.Append))
            using (var sw = new StreamWriter(fs))
                sw.WriteLine($"{row};{first};{last};{num}");

            calibrationList.Add(num);
        }
        return calibrationList.Sum();
    }
    private int GetNumber (string num)
    {
        return num switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => int.Parse(num)
        };
    }
}

