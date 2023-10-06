using Microsoft.Extensions.DependencyInjection;
using Refit;
using StoneChallengeConsumptionApi.Application.UseCases.Consumptions;
using StoneChallengeConsumptionApi.Application.UseCases.Consumptions.Interfaces;
using StoneChallengeConsumptionApi.Domain.Clients;

namespace StoneChallengeConsumptionApi.Infra.CrossCutting.IoC;

public static class BootStrapper
{
    public static IServiceProvider ServiceProvider = null;

    public static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .RegisterRepositories()
            .RegisterServicesAndUseCases()
            .RegisterRefitClients();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    private static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    private static IServiceCollection RegisterServicesAndUseCases(this IServiceCollection serviceCollection)
    {
        #region UseCases
        
        serviceCollection.AddScoped<ICreateConsumptionsUseCase, HandleConsumptionsUseCase>();

        #endregion

        return serviceCollection;
    }

    public static T GetInstance<T>()
    {
        if (ServiceProvider is null)
            throw new InvalidOperationException("Os services não foram registrados.");

        return (T)ServiceProvider.GetService(typeof(T));
    }
    
    private static IServiceCollection RegisterRefitClients(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddRefitClient<ICustomersApiClient>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new  Uri("http://localhost:5000/api");
        });
        
        serviceCollection.AddRefitClient<IBillingsApiClient>().ConfigureHttpClient(c =>
        {
            c.BaseAddress = new  Uri("http://localhost:5134/api");
        });

        return serviceCollection;
    }
}