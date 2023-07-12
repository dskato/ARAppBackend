using Infrastructure.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
