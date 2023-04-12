using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ARAppBackend.Extensions.Servers
{
    public class ServerExtension
    {

        public static void ConfigureSQLServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("ArAppConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("Infrastructure");
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(90), errorNumbersToAdd: null);
                    });
                }, ServiceLifetime.Transient);


        }

    }
}
