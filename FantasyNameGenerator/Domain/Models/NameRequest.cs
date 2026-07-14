namespace FantasyNameGenerator.Models
{
    public enum Race
    {
        Human,
        Dwarven,
        Orc,
        Elf,
    }

    public enum Gender
    {
        Male,
        Female,
        Random
    }

    public enum Length
    {
        Short,
        Long
    }

    public record NameRequest(
        Race Race,
        Gender? Gender = Gender.Random,
        Length? Length = Length.Short,
        int? NumberOfNames = 1,
        int? Seed = 12345);
}
