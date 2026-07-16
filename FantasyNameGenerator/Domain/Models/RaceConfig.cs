namespace FantasyNameGenerator.Domain.Models;

public static class RaceCatalog
{
    public record RaceConfig(
      Race Race,
      bool Enabled);


    /// <summary>
    /// A configuration class that holds the availability of different data.
    /// To be used to encapsule the availability of different features in the generator.
    /// </summary>
    public interface IFeatureAvailabilityConfig
    {
        IReadOnlyList<RaceConfig> Races { get; }
        bool IsRaceSupported(Race race);
    }

    public class FeatureAvailabilityConfig : IFeatureAvailabilityConfig
    {
        public FeatureAvailabilityConfig(params RaceConfig[] races)
        {
            Races = races;
        }

        public IReadOnlyList<RaceConfig> Races { get; }

        /// <summary>
        /// To check if a race is currently supported by the generator.
        /// </summary>
        /// <param name="race">The race to check.</param>
        /// <returns>False if the race is not supported, true otherwise.</returns>
        public bool IsRaceSupported(Race race)
            => Races.Any(r => r.Race == race && r.Enabled);
    }
}