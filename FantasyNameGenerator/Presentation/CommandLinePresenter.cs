namespace FantasyNameGenerator.UserInterface
{
    public class CommandLinePresenter
    {
        public void PrintName(string name)
        {
            Console.WriteLine();
            Console.WriteLine("=== Fantasy Name Generator ===");
            Console.WriteLine();
            Console.WriteLine(name);
        }
    }
}
