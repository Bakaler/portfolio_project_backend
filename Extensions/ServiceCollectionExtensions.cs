using Microsoft.Extensions.DependencyInjection;

namespace PortfolioBackend.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUpdateLineHandlers(this IServiceCollection services)
        {
            services.AddScoped<IExpUpdateLines, ExpUpdateLines>();
            services.AddScoped<ITermUpdateLines, TermUpdateLines>();
            services.AddScoped<IFactorUpdateLines, FactorUpdateLines>();
            services.AddScoped<IPowerUpdateLines, PowerUpdateLines>();
            services.AddScoped<IFunctionUpdateLines, FunctionUpdateLines>();
            services.AddScoped<IDigitUpdateLines, DigitUpdateLines>();
            return services;
        }
    }
}