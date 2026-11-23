using LearningBasic.Labs.Infrastructure;

namespace LearningBasic.Labs.Lab03_Patterns;

public class Lab03 : ILab
{
    public int Number => 3;
    public string Title => "Logic patterns";

    public void Run()
    {
        Check.True("3.1 Pair exists (1,2,4,7,11 -> 15)", () => Exercises.HasPairWithSum([1, 2, 4, 7, 11], 15));
        Check.True("3.1 No pair (1,2,4 -> 10)", () => !Exercises.HasPairWithSum([1, 2, 4], 10));
        Check.True("3.1 Empty array", () => !Exercises.HasPairWithSum([], 5));

        Check.Equal("3.2 MaxWindowSum k=3", 9, () => Exercises.MaxWindowSum([2, 1, 5, 1, 3, 2], 3));
        Check.Equal("3.2 MaxWindowSum with negatives", -3, () => Exercises.MaxWindowSum([-5, -3, -8], 1));
        Check.Throws<ArgumentException>("3.2 k bigger than array", () => Exercises.MaxWindowSum([1, 2], 3));

        Check.Sequence("3.3 RangeSums", new[] { 6, 14, 5 },
            () => Exercises.RangeSums([1, 2, 3, 4, 5], [(0, 2), (1, 4), (4, 4)]));

        Check.Equal("3.4 BinarySearch found", 4, () => Exercises.BinarySearch([1, 3, 5, 7, 9, 11], 9));
        Check.Equal("3.4 BinarySearch first element", 0, () => Exercises.BinarySearch([1, 3, 5], 1));
        Check.Equal("3.4 BinarySearch missing", -1, () => Exercises.BinarySearch([1, 3, 5], 4));
        Check.Equal("3.4 BinarySearch empty", -1, () => Exercises.BinarySearch([], 4));

        Check.Sequence("3.5 NextGreater [2,1,3]", new[] { 3, 3, -1 }, () => Exercises.NextGreater([2, 1, 3]));
        Check.Sequence("3.5 NextGreater [4,5,2,25]", new[] { 5, 25, 25, -1 }, () => Exercises.NextGreater([4, 5, 2, 25]));

        Check.Equal("3.6 ShortestPath around a wall", 5, () => Exercises.ShortestPath([
            "S.#.",
            "..#.",
            "...E"]));
        Check.Equal("3.6 ShortestPath blocked", -1, () => Exercises.ShortestPath([
            "S#E"]));
    }
}