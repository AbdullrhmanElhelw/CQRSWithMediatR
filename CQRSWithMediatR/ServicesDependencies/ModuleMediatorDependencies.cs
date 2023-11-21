using System.Reflection;

namespace CQRSWithMediatR.ServicesDependencies;

public static class ModuleMediatorDependencies
{
    public static IServiceCollection AddMeidatrDependencies(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}
