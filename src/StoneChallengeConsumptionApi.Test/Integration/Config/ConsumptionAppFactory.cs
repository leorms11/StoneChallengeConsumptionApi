using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using StoneChallengeConsumptionApi.Presentation;

[assembly: InternalsVisibleTo("StoneChallenge.BillingApi.Test.Fixtures")]
namespace StoneChallengeConsumptionApi.Test.Integration.Config;

internal class ConsumptionAppFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.UseContentRoot(Environment.CurrentDirectory);
        builder.UseEnvironment("Testing");
    }
}