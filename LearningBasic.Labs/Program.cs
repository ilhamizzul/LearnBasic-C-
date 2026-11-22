using LearningBasic.Labs.Infrastructure;

var labs = new List<ILab>
{
    new LearningBasic.Labs.Lab01_Fundamentals.Lab01(),
    new LearningBasic.Labs.Lab02_Oop.Lab02()
};

while (true)
{
    Console.WriteLine("\n=== Leaning Labs ===");
    foreach (var lab in labs) Console.WriteLine($"  {lab.Number}. {lab.Title}");
    Console.Write("Lab Number (A = all, Q = quit)");
    var input = Console.ReadLine()?.Trim().ToUpperInvariant();
    if (input is null or "Q") break;

    var selected = input == "A" ? labs : labs.Where(l => l.Number.ToString() == input).ToList();
    if (selected.Count == 0) { Console.WriteLine("Unknown lab."); continue; }

    Check.Reset();
    foreach (var lab in selected)
    {
        Console.WriteLine($"\n--- Lab {lab.Number}: {lab.Title} ---");
        lab.Run();
    }
    Console.WriteLine($"\nPassed {Check.Passed} | Failed {Check.Failed} | Todo {Check.Todo}");
}