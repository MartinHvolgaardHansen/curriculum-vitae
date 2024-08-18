using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CurriculumVitae.GraphQlApi;

public class Program
{
    public static Task Main(string[] args) => Host
        .CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>())
        .Build()
        .RunAsync();
}
