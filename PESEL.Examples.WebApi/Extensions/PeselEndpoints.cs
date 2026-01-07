using PESEL;
using PESEL.Examples.WebApi.Models;
using PESEL.Models;
using PESEL.Validators.Impl;
using Scalar.AspNetCore;
using System.Reflection;

public static class PeselEndpoints
{
    public static IEndpointRouteBuilder MapPeselEndpoints(this IEndpointRouteBuilder app)
    {
        // ============================
        // PESEL domain endpoints
        // ============================
        var pesel = app.MapGroup("/api/pesel")
                       .WithTags("PESEL");

        pesel.MapGet("/validate/{pesel}", ValidatePesel)
             .WithName("ValidatePesel")
             .WithSummary("Validates PESEL number")
             .WithDescription("Validates a PESEL number and returns validation result.");

        pesel.MapGet("/generate", GeneratePesel)
             .WithName("GeneratePesel")
             .WithSummary("Generates PESEL numbers for a given birth date")
             .WithDescription(
                 "Generates a list of valid PESEL numbers for the specified birth date. " +
                 "The number of generated values can be limited using the 'take' query parameter."
             );

        // ============================
        // System / meta endpoints
        // ============================
        var system = app.MapGroup("/api/system")
                        .WithTags("System");

        system.MapGet("/version", GetVersion)
              .WithName("GetVersion")
              .WithSummary("Returns application and dependency version information")
              .WithDescription(
                  "Returns current application version, runtime version, " +
                  "and versions of referenced PESEL libraries resolved from assemblies."
              );

        return app;
    }

    private static IResult ValidatePesel(string pesel)
    {
        if (string.IsNullOrWhiteSpace(pesel))
            return Results.BadRequest("PESEL cannot be empty.");

        var entity = new PeselEntity(pesel);
        var validator = new PeselValidator();
        var result = validator.Validate(entity);

        return Results.Ok(new
        {
            isValid = result.IsValid,
            errors = result.Message,
            result.Pesel
        });
    }

    private static IResult GeneratePesel(DateTime date, int take = 20)
    {
        if (take is < 1 or > 1000)
            return Results.BadRequest("Parameter 'take' must be between 1 and 1000.");

        var pesels = PeselGenerator.Generate(date)
                                   .Take(take)
                                   .ToArray();

        return Results.Ok(new
        {
            date = date.ToString("yyyy-MM-dd"),
            count = pesels.Length,
            values = pesels
        });
    }
    private static IResult GetVersion()
    {
        var appAssembly = Assembly.GetExecutingAssembly();

        var appVersion =
            appAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion
            ?? appAssembly.GetName().Version?.ToString()
            ?? "unknown";

        var dependencies = new[]
        {
        GetDependency(typeof(PESEL.PeselGenerator).Assembly, "PESEL"),
        GetDependency(typeof(PESEL.Models.PeselEntity).Assembly, "PESEL.Models")
    };

        var model = new VersionInfo(
            Application: "PESEL.Examples.WebApi",
            ApplicationVersion: appVersion,
            RuntimeVersion: Environment.Version.ToString(),
            Dependencies: dependencies
        );

        return Results.Ok(model);
    }

    private static DependencyInfo GetDependency(Assembly assembly, string name)
    {
        var version =
            assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion
            ?? assembly.GetName().Version?.ToString()
            ?? "unknown";

        return new DependencyInfo(name, version);
    }
}
