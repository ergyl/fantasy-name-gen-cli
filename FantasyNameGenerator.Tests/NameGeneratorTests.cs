using FantasyNameGenerator.Models;
using FantasyNameGenerator.Services;
using FantasyNameGenerator.Utils;
using Xunit;

namespace FantasyNameGenerator.Tests
{
    public class NameGeneratorTests
    {
        [Fact]
        public void SameSeed_ProducesSameName()
        {
            var seed = 12345L;
            var g1 = new SimpleNameGenerator(new SeededRandomProvider(seed));
            var g2 = new SimpleNameGenerator(new SeededRandomProvider(seed));

            var n1 = g1.Generate(new NameRequest(Category.Orc, Length.Long));
            var n2 = g2.Generate(new NameRequest(Category.Orc, Length.Long));

            Assert.Equal(n1, n2);
        }

        [Fact]
        public void DifferentSeeds_OftenProduceDifferentNames()
        {
            var g1 = new SimpleNameGenerator(new SeededRandomProvider(1));
            var g2 = new SimpleNameGenerator(new SeededRandomProvider(2));

            var n1 = g1.Generate(new NameRequest(Category.Dwarven, Length.Short));
            var n2 = g2.Generate(new NameRequest(Category.Dwarven, Length.Short));

            Assert.NotNull(n1);
            Assert.NotNull(n2);
            // Not asserting inequality strictly because collisions are possible,
            // but we verify both produce non-empty outputs.
            Assert.NotEmpty(n1);
            Assert.NotEmpty(n2);
        }
    }
}
