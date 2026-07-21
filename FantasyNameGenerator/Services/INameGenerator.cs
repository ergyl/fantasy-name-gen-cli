namespace FantasyNameGenerator.Services;

public interface INameGenerator
{
    List<string> Generate(NameRequest request);
}
