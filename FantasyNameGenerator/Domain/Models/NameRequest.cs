namespace FantasyNameGenerator.Models
{
    public enum Race
    {
        Orc,
        Dwarven
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
        Race Race = Race.Orc,
        Gender Gender = Gender.Random,
        Length Length = Length.Short);
}
