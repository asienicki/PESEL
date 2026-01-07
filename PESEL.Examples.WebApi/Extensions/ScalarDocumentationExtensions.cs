using Scalar.AspNetCore;

namespace PESEL.Examples.WebApi.Extensions;

public static class ScalarDocumentationExtensions
{
    public static IApplicationBuilder EnableScalarDocs(this WebApplication app)
    {
        app.MapOpenApi();

        app.MapScalarApiReference(options =>
        {
            options.WithTheme(ScalarTheme.Saturn)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
            .WithTitle("PESEL API");
        })
            .AllowAnonymous();

        app.MapScalarApiReference("/")
            .AllowAnonymous();

        return app;
    }
}
