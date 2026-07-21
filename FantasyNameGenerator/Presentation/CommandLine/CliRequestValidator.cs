namespace FantasyNameGenerator.Presentation.CommandLine;

/// <summary>
/// Validates the raw user input via command-line request parameters to ensure they meet the application's requirements and constraints.
/// </summary>
public static class CliRequestValidator
{
    private const int MinNumberOfNames = 1;
    private const int MaxNumberOfNames = 100;

    public static Result<bool> Validate(CliRequest request)
    {
        if (request.Male && request.Female)
        {
            return Result<bool>.Failure(
                "Cannot use --male and --female together.");
        }

        if (request.Short && request.Full)
        {
            return Result<bool>.Failure(
                "Cannot use --short and --full together.");
        }

        if (!IsValidNumberOfNamesOption(request.NumberOfNames))
        {
            return Result<bool>.Failure(
                "Number of names to generate must be between 1 and 100.");
        }

        return Result<bool>.Success(true);
    }

    private static bool IsValidNumberOfNamesOption(int n)
    {
        // UPPER BOUND: 100 is an arbitrary limit to prevent excessive name generation
        return n >= MinNumberOfNames && n <= MaxNumberOfNames;
    }


}