using System;
using CurriculumVitae.Shared.DtoModels;
using GraphQL.Instrumentation;
using GraphQL.Types;

namespace CurriculumVitae.GraphQlApi.GraphQlSchema;

public class CurriculumVitaeSchema : Schema
{
    public CurriculumVitaeSchema(IServiceProvider provider)
        : base(provider)
    {
        Query = (Query)provider.GetService(typeof(Query)) ?? throw new InvalidOperationException();
        // Mutation = (StarWarsMutation)provider.GetService(typeof(StarWarsMutation)) ?? throw new InvalidOperationException();

        FieldMiddleware.Use(new InstrumentFieldsMiddleware());
    }
}