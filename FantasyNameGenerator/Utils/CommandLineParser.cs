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

        // Required: race
        if (!Enum.TryParse<Race>(
                args[0],
                true,
                out var race))
        {
            return new ParseResult.Failure($"Invalid race: '{args[0]}'");
        }

        Gender? gender = null;
        Length? length = null;
        int? numberOfNames = null;
        long? seed = null;

        int i = 1;

        // Optional: gender
        if (i < args.Length &&
            Enum.TryParse<Gender>(
                args[i],
                true,
                out var parsedGender))
        {
            gender = parsedGender;
            i++;
        }

        // Optional: length
        if (i < args.Length &&
            Enum.TryParse<Length>(
                args[i],
                true,
                out var parsedLength))
        {
            length = parsedLength;
            i++;
        }

        // Remaining args are options
        while (i < args.Length)
        {
            switch (args[i])
            {
                case "--seed":
                    if (i + 1 >= args.Length ||
                        !int.TryParse(args[i + 1], out var seedValue))
                    {
                        return new ParseResult.Failure("--seed requires a valid integer value.");
                    }

                    seed = seedValue;
                    i += 2;
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


                default:
                    return new ParseResult.Failure("Unrecognized option specified.");
            }
        }

        return new ParseResult.Success(race, gender, length, numberOfNames, seed);
    }

    public abstract record ParseResult
    {
        public sealed record Success(Race Race, Gender? Gender, Length? Length, int? NumberOfNames, long? Seed) : ParseResult;
        public sealed record Failure(string Message) : ParseResult;
    }
}