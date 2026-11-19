using System;
using System.Collections.Generic;
using System.Text;

namespace LearningBasic.Labs.Lab01_Fundamentals;

public static class Exercises {
    // 1.1 Count the words. Words are separated by one or more spaces.
    public static int CountWords(string? text)
    {
        if (String.IsNullOrWhiteSpace(text)) return 0;

        List<string> words = new List<string>();
        words = text.Split().ToList();
        return words.Count;
    }

    // 1.2 Join numbers with "-" using a StringBuilder (not string.Join).
    public static string JoinWithDash(int[] numbers)
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < numbers.Length; i++)
        {
            if (i > 0)
            {
                sb.Append("-");
            }
            sb.Append(numbers[i]);
        }

        return sb.ToString();
    }

    // 1.3 Parse with int.TryParse. Return null when it's not a whole number, or is <= 0.
    public static int? TryParseQuantity(string? input) {
        if (int.TryParse(input, out int qty))
        {
            return qty > 0 ? qty : null;
        }
        return null;
    }

    // 1.4 Add the bonus to every salary IN PLACE: the caller's list must change.
    public static void AddBonusInPlace(List<decimal> salaries, decimal bonus)
    {
        for(int i = 0; i < salaries.Count; i++ )
        {
            salaries[i] += bonus;
        }
    }

    // 1.5 Swap the two caller variables using ref.
    public static void Swap(ref int a, ref int b) {
        (a, b) = (b, a);
    }

    // 1.6 Return a NEW array with every value doubled. The source must NOT change.
    public static int[] DoubledCopy(int[] source)
    {
        int[] response = new int[source.Length];
        for(int i = 0; i < source.Length; i++)
        {
            response[i] = source[i] * 2;
        }
        return response;
    }
}

