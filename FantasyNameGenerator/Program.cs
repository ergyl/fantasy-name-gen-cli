// Very thin composition root - keeping logic out of Program.cs
var argsList = args ?? Array.Empty<string>();

// Simple parsing: expecting `category length` e.g. `orc -f`
Category category = Category.Orc;
Length length = Length.Short;
long? seed = null;

if (argsList.Length >= 1)
{
    Enum.TryParse<Category>(argsList[0], true, out category);
}
if (argsList.Length >= 2)
{
    Enum.TryParse<Length>(argsList[1], true, out length);
}
// optional --seed 123
for (int i = 0; i < argsList.Length - 1; i++)
{
    if (argsList[i].Equals("--seed", StringComparison.OrdinalIgnoreCase))
    {
        if (long.TryParse(argsList[i + 1], out var s)) seed = s;
    }
}

ISeededRandom rand = seed.HasValue ? new SeededRandomProvider(seed.Value) : new SeededRandomProvider();
INameGenerator generator = new SimpleNameGenerator(rand);
var request = new NameRequest(category, length);
var name = generator.Generate(request);

var presenter = new ConsolePresenter();
presenter.PrintName(name);
