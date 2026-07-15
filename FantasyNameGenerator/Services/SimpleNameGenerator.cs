namespace FantasyNameGenerator.Services
{
    public class SimpleNameGenerator : INameGenerator
    {
        private readonly ISeededRandom _rand;

        private static readonly string[] OrcPrefixes = { "Gor", "Brak", "Uzg", "Kr" };
        private static readonly string[] OrcSuffixesLong = { "thak", "mash", "gor", "zugoth" };
        private static readonly string[] OrcSuffixesShort = { "uk", "arg", "og" };

        private static readonly string[] DwarfPrefixes = { "Thro", "Dur", "Balin", "Gim" };
        private static readonly string[] DwarfSuffixesLong = { "insson", "grum", "dain", "mir" };
        private static readonly string[] DwarfSuffixesShort = { "in", "ur", "or" };

        public SimpleNameGenerator(ISeededRandom rand) => _rand = rand;

        public string Generate(NameRequest request)
        {
            return "";
        }


        private string GenerateHuman(NameRequest length)
        {
            return "";
        }

        private string GenerateDwarf(NameRequest length)
        {
            return "";
        }

        private string GenerateOrc(NameRequest length)
        {
            throw new NotImplementedException("Orc name generation is not implemented yet.");
        }

        private string GenerateElf(NameRequest length)
        {
            throw new NotImplementedException("Elf name generation is not implemented yet.");
        }
    }
}
