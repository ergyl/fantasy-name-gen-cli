namespace FantasyNameGenerator.Utils;

public class SeededRandomProvider : ISeededRandom
{
    private readonly Random _rng;

    public SeededRandomProvider() : this(Environment.TickCount) { }

    public SeededRandomProvider(long seed)
    {
        /* Non-deterministic behavior.
        Pseudo-random number generator (PRNG) seeded with a long value.*/
        _rng = new Random((int)(seed & 0xFFFFFFFF));
    }

    public int Next(int maxValue) => _rng.Next(maxValue);
}
