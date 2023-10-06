using StoneChallengeConsumptionApi.Presentation.MiddleWares;

namespace StoneChallengeConsumptionApi.Presentation.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder builder)
        => builder.UseMiddleware<GlobalErrorHandlingMiddleware>();
}