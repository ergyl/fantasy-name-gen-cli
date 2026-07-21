
/// <summary>
/// Maps the command line request to the internal request model.
/// Flags and options aswell as their values are mapped to the internal request model.
/// </summary>
public static class CliRequestMapper
{
    public static Result<NameRequest> Map(CliRequest request)
    {
        // Parse ´race´ option to enum
        if (!Enum.TryParse<Race>(request.Race, true, out var race))
        {
            return Result<NameRequest>.Failure(
                $"Invalid race specified: {request.Race}"
            );
        }

        var gender = ResolveGender(request);
        var length = ResolveLength(request);

        var domainRequest = new NameRequest(
        race,
        gender,
        length,
        request.NumberOfNames,
        request.Seed);

        return Result<NameRequest>.Success(domainRequest);
    }

    private static Gender ResolveGender(CliRequest request)
    {
        if (request.Male)
        {
            return Gender.Male;
        }

        if (request.Female)
        {
            return Gender.Female;
        }

        // Default value
        return Gender.Random;
    }

    private static Length ResolveLength(CliRequest request)
    {
        if (request.Full)
        {
            return Length.Long;
        }

        // Default value
        return Length.Short;
    }
}