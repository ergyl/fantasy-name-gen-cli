namespace FantasyNameGenerator.Utils;

/*
Simple parsing: expecting `ff-name <race> [gender] [length] [options]`

args[0] = "human" (required)
args[1] = "male" (optional positional)
args[2] = "short" (optional positional)
args[3] = "--seed" (optional flag)
args[4] = "123" (optional flag)
*/
public static class CommandLineParser
{
    public static ParseResult Parse(
        string[] args)
    {

        if (args.Length == 0)
        {
            return new ParseResult.Failure("No arguments provided. Race argument is required.");
        }

        if (args.Length == 1 && (args[0] == "-h" || args[0] == "--help"))
        {
            return new ParseResult.Help();
        }

        // Required: race
        var rawRace = args[0];

        // Reject null/empty/whitespace
        if (string.IsNullOrWhiteSpace(rawRace))
        {
            return new ParseResult.Failure("Race cannot be empty or include whitespace.");
        }

        // Reject leading/trailing whitespace
        if (rawRace != rawRace.Trim())
        {
            return new ParseResult.Failure($"Unallowed leading/trailing whitespace in race: '{rawRace}'");
        }

        var validRaces = Enum.GetNames<Race>()
            .Select(r => r.ToLowerInvariant());


        // Reject incorrect casing by requiring exact enum name match
        if (!validRaces.Contains(rawRace))
        {
            return new ParseResult.Failure($"Invalid race: '{rawRace}'");
        }

        var race = Enum.Parse<Race>(rawRace, ignoreCase: true);

        Gender? gender = null;
        Length? length = null;
        int? numberOfNames = null;
        long? seed = null;

        int i = 1;

        // Optional positional: gender at index 1
        if (i < args.Length &&
            Enum.TryParse<Gender>(args[i], true, out var parsedGender))
        {
            gender = parsedGender;
            i++;
        }

        // Optional positional: length at index 2
        if (i < args.Length &&
            Enum.TryParse<Length>(args[i], true, out var parsedLength))
        {
            length = parsedLength;
            i++;
        }

        // Parse remaining args as option flags
        while (i < args.Length)
        {
            switch (args[i])
            {
                case "-m":
                case "--male":
                    gender = Gender.Male;
                    i++;
                    break;

                case "-f":
                case "--female":
                    gender = Gender.Female;
                    i++;
                    break;

                case "-s":
                case "--short":
                    length = Length.Short;
                    i++;
                    break;

                case "-l":
                case "--full":
                    length = Length.Long;
                    i++;
                    break;

                case "-n":
                case "--number":
                    if (i + 1 >= args.Length ||
                        !int.TryParse(args[i + 1], out var numberValue))
                    {
                        return new ParseResult.Failure("-n/--number requires a valid integer value.");
                    }
                    numberOfNames = numberValue;
                    i += 2;
                    break;

                case "--seed":
                    if (i + 1 >= args.Length ||
                        !long.TryParse(args[i + 1], out var seedValue))
                    {
                        return new ParseResult.Failure("--seed requires a valid integer value.");
                    }
                    seed = seedValue;
                    i += 2;
                    break;

                default:
                    return new ParseResult.Failure($"Unrecognized option: '{args[i]}'");
            }
        }

        return new ParseResult.Success(race, gender, length, numberOfNames, seed);
    }

    public abstract record ParseResult
    {
        public sealed record Success(Race Race, Gender? Gender, Length? Length, int? NumberOfNames, long? Seed) : ParseResult;
        public sealed record Failure(string Message) : ParseResult;
        public sealed record Help : ParseResult;
    }
}