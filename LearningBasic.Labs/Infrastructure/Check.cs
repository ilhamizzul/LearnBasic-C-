using System.Collections;

namespace LearningBasic.Labs.Infrastructure;

public interface ILab
{
    int Number { get; }
    string Title { get; }
    void Run();
}

public static class Check
{
    public static int Passed { get; private set; }
    public static int Failed { get; private set; }
    public static int Todo { get; private set; }

    public static void Reset() => Passed = Failed = Todo = 0;

    public static void Equal<T>(string name, T expected, Func<T> actual) =>
        Run(name, () =>
        {
            var a = actual();
            return EqualityComparer<T>.Default.Equals(expected, a)
                ? null
                : $"expected {Format(expected)} but got {Format(a)}";
        });

    public static void Sequence<T>(string name, IEnumerable<T> expected, Func<IEnumerable<T>?> actual) =>
        Run(name, () =>
        {
            var a = actual()?.ToList();
            var e = expected.ToList();
            return a is not null && e.SequenceEqual(a)
                ? null
                : $"expected {Format(e)} but got {Format(a)}";
        });

    public static void True(string name, Func<bool> condition, string whyItFailed = "condition was false") =>
        Run(name, () => condition() ? null : whyItFailed);

    public static void Throws<TException>(string name, Action action) where TException : Exception =>
        Run(name, () =>
        {
            try { action(); }
            catch (TException) { return null; }
            return $"expected {typeof(TException).Name} but nothing was thrown";
        });

    private static void Run(string name, Func<string?> test)
    {
        try
        {
            var error = test();
            if (error is null) Print("PASS", ConsoleColor.Green, name, null, () => Passed++);
            else Print("FAIL", ConsoleColor.Red, name, error, () => Failed++);
        }
        catch (NotImplementedException)
        {
            Print("TODO", ConsoleColor.Yellow, name, null, () => Todo++);
        }
        catch (Exception ex)
        {
            Print("FAIL", ConsoleColor.Red, name, $"{ex.GetType().Name}: {ex.Message}", () => Failed++);
        }
    }

    private static void Print(string label, ConsoleColor color, string name, string? detail, Action count)
    {
        count();
        Console.ForegroundColor = color;
        Console.Write($"  [{label}] ");
        Console.ResetColor();
        Console.WriteLine(detail is null ? name : $"{name} -> {detail}");
    }

    private static string Format(object? value) => value switch
    {
        null => "null",
        string s => $"\"{s}\"",
        IEnumerable items => "[" + string.Join(", ", items.Cast<object?>().Select(Format)) + "]",
        _ => value.ToString() ?? "null"
    };
}