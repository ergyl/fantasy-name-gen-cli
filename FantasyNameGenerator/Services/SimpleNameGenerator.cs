namespace FantasyNameGenerator.Services;

public class SimpleNameGenerator : INameGenerator
{
    private readonly ISeededRandom _rand;

    public SimpleNameGenerator(ISeededRandom rand) => _rand = rand;

    public List<string> Generate(NameRequest request)
    {
        return [GenerateHuman(request)];
    }

    private string GenerateHuman(NameRequest request)
    {
        return "Bob Smith";
    }

    private string GenerateHuman(NameRequest request, int numberOfNames)
    {
        return "";
    }

    private string GenerateDwarf(NameRequest request)
    {
        return "";
    }

    private string GenerateDwarf(NameRequest request, int numberOfNames)
    {
        return "";
    }

    private string GenerateOrc(NameRequest request)
    {
        throw new NotImplementedException("Orc name generation is not implemented yet.");
    }

    private string GenerateOrc(NameRequest request, int numberOfNames)
    {
        throw new NotImplementedException("Orc name generation is not implemented yet.");
    }
    private string GenerateElf(NameRequest request)
    {
        throw new NotImplementedException("Elf name generation is not implemented yet.");
    }

    private string GenerateElf(NameRequest request, int numberOfNames)
    {
        throw new NotImplementedException("Elf name generation is not implemented yet.");
    }
}

