using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace CurriculumVitae.GraphQlApi.GraphQlSchema;

public class StarWarsQuery : ObjectGraphType<object>
{
    public StarWarsQuery(StarWarsData data)
    {
        Name = "Query";

        FieldAsync<CharacterInterface>("hero", resolve: async context => await data.GetDroidByIdAsync("3"));
        FieldAsync<HumanType>(
            "human",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the human" }
            ),
            resolve: async context => await data.GetHumanByIdAsync(context.GetArgument<string>("id"))
        );

        Func<IResolveFieldContext, string, Task<Droid>> func = (context, id) => data.GetDroidByIdAsync(id);

        FieldDelegate<DroidType>(
            "droid",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the droid" }
            ),
            resolve: func
        );
    }
}

public class StarWarsData
{
    private readonly List<Human> _humans = new List<Human>();
    private readonly List<Droid> _droids = new List<Droid>();

    public StarWarsData()
    {
        _humans.Add(new Human
        {
            Id = "1",
            Name = "Luke",
            Friends = new[] { "3", "4" },
            AppearsIn = new[] { 4, 5, 6 },
            HomePlanet = "Tatooine"
        });
        _humans.Add(new Human
        {
            Id = "2",
            Name = "Vader",
            AppearsIn = new[] { 4, 5, 6 },
            HomePlanet = "Tatooine"
        });

        _droids.Add(new Droid
        {
            Id = "3",
            Name = "R2-D2",
            Friends = new[] { "1", "4" },
            AppearsIn = new[] { 4, 5, 6 },
            PrimaryFunction = "Astromech"
        });
        _droids.Add(new Droid
        {
            Id = "4",
            Name = "C-3PO",
            AppearsIn = new[] { 4, 5, 6 },
            PrimaryFunction = "Protocol"
        });
    }

    public IEnumerable<StarWarsCharacter> GetFriends(StarWarsCharacter character)
    {
        if (character == null)
        {
            return null;
        }

        var friends = new List<StarWarsCharacter>();
        var lookup = character.Friends;
        if (lookup != null)
        {
            foreach (var h in _humans.Where(h => lookup.Contains(h.Id)))
                friends.Add(h);
            foreach (var d in _droids.Where(d => lookup.Contains(d.Id)))
                friends.Add(d);
        }
        return friends;
    }

    public Task<Human> GetHumanByIdAsync(string id)
    {
        return Task.FromResult(_humans.FirstOrDefault(h => h.Id == id));
    }

    public Task<Droid> GetDroidByIdAsync(string id)
    {
        return Task.FromResult(_droids.FirstOrDefault(h => h.Id == id));
    }

    public Human AddHuman(Human human)
    {
        human.Id = Guid.NewGuid().ToString();
        _humans.Add(human);
        return human;
    }
}

public class DroidType : ObjectGraphType<Droid>
{
    public DroidType(StarWarsData data)
    {
        Name = "Droid";
        Description = "A mechanical creature in the Star Wars universe.";

        Field(d => d.Id).Description("The id of the droid.");
        Field(d => d.Name, nullable: true).Description("The name of the droid.");

        Field<ListGraphType<CharacterInterface>>(
            "friends",
            resolve: context => data.GetFriends(context.Source)
        );
        Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");
        Field(d => d.PrimaryFunction, nullable: true).Description("The primary function of the droid.");

        Interface<CharacterInterface>();
    }
}

public class HumanType : ObjectGraphType<Human>
{
    public HumanType(StarWarsData data)
    {
        Name = "Human";

        Field(h => h.Id).Description("The id of the human.");
        Field(h => h.Name, nullable: true).Description("The name of the human.");

        Field<ListGraphType<CharacterInterface>>(
            "friends",
            resolve: context => data.GetFriends(context.Source)
        );
        Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");

        Field(h => h.HomePlanet, nullable: true).Description("The home planet of the human.");

        Interface<CharacterInterface>();
    }
}

public class EpisodeEnum : EnumerationGraphType
{
    public EpisodeEnum()
    {
        Name = "Episode";
        Description = "One of the films in the Star Wars Trilogy.";
        Add("NEWHOPE", 4, "Released in 1977.");
        Add("EMPIRE", 5, "Released in 1980.");
        Add("JEDI", 6, "Released in 1983.");
    }
}

public enum Episodes
{
    NEWHOPE = 4,
    EMPIRE = 5,
    JEDI = 6
}

public class CharacterInterface : InterfaceGraphType<StarWarsCharacter>
{
    public CharacterInterface()
    {
        Name = "Character";

        Field(d => d.Id).Description("The id of the character.");
        Field(d => d.Name, nullable: true).Description("The name of the character.");

        Field<ListGraphType<CharacterInterface>>("friends");
        Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");
    }
}


public abstract class StarWarsCharacter
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string[] Friends { get; set; }
    public int[] AppearsIn { get; set; }
}

public class Human : StarWarsCharacter
{
    public string HomePlanet { get; set; }
}

public class Droid : StarWarsCharacter
{
    public string PrimaryFunction { get; set; }
}