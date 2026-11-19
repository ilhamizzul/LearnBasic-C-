using LearningBasic.Labs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningBasic.Labs.Lab01_Fundamentals;

public class Lab01 : ILab
{
    public int Number => 1;
    public string Title => "C# Fundamentals";

    public void Run()
    {
        Check.Equal("1.1 CountWords: normal sentence", 4, () => Exercises.CountWords("the quick brown fox"));
        Check.Equal("1.1 Countwords: null", 0, () => Exercises.CountWords(null));
        Check.Equal("1.1 Countwords: only spaces", 0, () => Exercises.CountWords("     "));

        Check.Equal("1.2 JoinWithDash: 1,2,3", "1-2-3", () => Exercises.JoinWithDash([1, 2, 3]));
        Check.Equal("1.2 JoinWithDash: empty", "", () => Exercises.JoinWithDash([]));

        Check.Equal<int?>("1.3 TryParseQuantity: \"25\"", 25, () => Exercises.TryParseQuantity("25"));
        Check.Equal<int?>("1.3 TryParseQuantity: \"abc\"", null, () => Exercises.TryParseQuantity("abc"));
        Check.Equal<int?>("1.3 TryParseQuantity: \"-3\"", null, () => Exercises.TryParseQuantity("-3"));
        Check.Equal<int?>("1.3 TryParseQuantity: \"0\"", null, () => Exercises.TryParseQuantity("0"));
        Check.Equal<int?>("1.3 TryParseQuantity: null", null, () => Exercises.TryParseQuantity(null));

        Check.Sequence("1.4 AddBonusInPlace changes the caller's list", new[] { 110m, 210m }, () =>
        {
            var salaries = new List<decimal> { 100m, 200m };
            Exercises.AddBonusInPlace(salaries, 10m);
            return salaries;
        });

        Check.True("1.5 Swap with ref", () =>
        {
            int x = 1, y = 2;
            Exercises.Swap(ref x, ref y);
            return x == 2 && y == 1;
        }, "x and y were not swapped");

        Check.Sequence("1.6 DoubledCopy returns doubled values", new[] { 2, 4, 6 }, () => Exercises.DoubledCopy([1, 2, 3]));
        Check.Sequence("1.6 DoubledCopy leaves the source unchanged", new[] { 1, 2, 3 }, () =>
        {
            int[] source = [1, 2, 3];
            Exercises.DoubledCopy(source);
            return source;
        });

    }
}