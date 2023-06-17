using Domain.Interfaces.Generics;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ARAppBackend.Extensions.Injections
{
    public class DependencyInjectionExtension
    {
        public static void ConfigureDependenciesInjectionsServices(WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddScoped<IApplicationService>(s => new ApplicationService(configuration, s.GetRequiredService<IClassDomainRepository>(), s.GetRequiredService<IGameDomainRepository>(), s.GetRequiredService<IGameMetricDomainRepository>(), s.GetRequiredService<IUserDomainRepository>(), s.GetRequiredService<IPasswordRestoreDomainRepository>(), s.GetRequiredService<IMClassUserDomainRepository>()));
            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddScoped<IClassDomainRepository, ClassRepository>();
            builder.Services.AddScoped<IGameDomainRepository, GameRepository>();
            builder.Services.AddScoped<IGameMetricDomainRepository, GameMetricRepository>();
            builder.Services.AddScoped<IUserDomainRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordRestoreDomainRepository, PasswordRestoreRepository>();
            builder.Services.AddScoped<IMClassUserDomainRepository, MClassUserRepository>();

        }
    }
}
