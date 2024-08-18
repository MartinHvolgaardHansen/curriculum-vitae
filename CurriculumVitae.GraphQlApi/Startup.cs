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
using CurriculumVitae.Shared.DtoModels;
using CurriculumVitae.Domain.Services;
using CurriculumVitae.DataAccess;
using CurriculumVitae.DataAccess.Repositories;

namespace CurriculumVitae.GraphQlApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();

        services.AddLogging(builder => builder.AddConsole());
        services.AddHttpContextAccessor();
        services.AddScoped<Query>();
        services.AddScoped<Mutation>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ISchema>(provider => new CurriculumVitaeSchema(provider));

        services.AddGraphQL(b => b
            .AddHttpMiddleware<ISchema>()
            .AddSystemTextJson()
            .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
            .AddGraphTypes(typeof(CurriculumVitaeSchema).Assembly)
            );
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseGraphQL<ISchema>();
    }
}