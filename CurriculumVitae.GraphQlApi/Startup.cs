using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CurriculumVitae.GraphQlApi.GraphQlSchema;

namespace CurriculumVitae.GraphQlApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddGraphQL(b => b
            .AddHttpMiddleware<ISchema>()
            .AddSystemTextJson()
            .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
            .AddSchema<StarWarsSchema>()
            .AddGraphTypes(typeof(StarWarsSchema).Assembly)
            );

        services.AddLogging(builder => builder.AddConsole());
        services.AddHttpContextAccessor();
        services.AddSingleton<StarWarsData>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseGraphQL<ISchema>();
        // app.UseGraphQLPlayground();
    }
}