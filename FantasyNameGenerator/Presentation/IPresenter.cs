namespace FantasyNameGenerator.Presentation;

public interface IPresenter
{
    void PrintError(string message);
    void PrintResult(List<string> names);
}