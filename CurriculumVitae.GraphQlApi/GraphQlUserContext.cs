using System.Collections.Generic;
using System.Security.Claims;

namespace CurriculumVitae.GraphQlApi;
public class GraphQLUserContext : Dictionary<string, object>
{
    public ClaimsPrincipal User { get; set; }
}
