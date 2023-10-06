using StoneChallengeConsumptionApi.Presentation.Extensions;

namespace StoneChallengeConsumptionApi.Presentation;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders().AddConsole();
        builder.UseStartup<Startup>(false)
            .Run();
    }
}