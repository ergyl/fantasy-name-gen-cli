namespace FantasyNameGenerator.Utils;

/// <summary>
/// Simple pseudo-random number generator (PRNG) that can be seeded for deterministic behavior.
/// </summary> 
public class SeededRandomProvider : ISeededRandom
{
    private readonly Random _rng;

    public SeededRandomProvider() : this(Environment.TickCount) { }

    public SeededRandomProvider(long seed)
    {
        /* Initialize the random number generator with the provided seed.
        This means that the sequence of random numbers generated will be the same for the same seed, which is useful for testing and reproducibility.
        For deterministic behavior, the seed can be set to a specific value. If no seed is provided, the current environment tick count is used, which will vary each time the application runs. */
        _rng = new Random((int)seed);
    }

    public int Next(int maxValue) => _rng.Next(maxValue);
}
