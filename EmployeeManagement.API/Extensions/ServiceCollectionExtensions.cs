using EmployeeManagementLibrary;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<ApplicationDbContext>(options =>
                options
                .UseSqlServer(configuration
                    .GetDefaultConnectionString()));
    }
}
