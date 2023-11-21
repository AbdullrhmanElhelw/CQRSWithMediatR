using CQRSWithMediatR.Services.Abstracts;
using CQRSWithMediatR.Services.Implementations;

namespace CQRSWithMediatR.ServicesDependencies;

public static class ModuleServicesDependencies
{
    public static IServiceCollection AddServciesDependencies(this IServiceCollection services)
    {
        services.AddTransient<IDepartmentService,DepartmentService>();
        return services;
    }
}
