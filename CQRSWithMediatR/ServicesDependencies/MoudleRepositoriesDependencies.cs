using CQRSWithMediatR.Repositories.DpartmentRepo;

namespace CQRSWithMediatR.ServicesDependencies;

public static class MoudleRepositoriesDependencies
{
    public static IServiceCollection AddRepositoriesDependencies(this IServiceCollection services)
    {
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        return services;
    }
}
