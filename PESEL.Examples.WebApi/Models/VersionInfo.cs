namespace PESEL.Examples.WebApi.Models
{
    public sealed record VersionInfo(
    string Application,
    string ApplicationVersion,
    string RuntimeVersion,
    DependencyInfo[] Dependencies
);

    public sealed record DependencyInfo(
        string Name,
        string Version
    );
}
