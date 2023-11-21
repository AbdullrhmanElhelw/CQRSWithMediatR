using CQRSWithMediatR.UnitOfWork;

namespace CQRSWithMediatR.ServicesDependencies;

public static class ModuleUnitOfWorkDependencies
{
    public static IServiceCollection AddUnitOfWrokDependencies(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork,UnitOfWork.UnitOfWork>();
        return services;
    }
}
