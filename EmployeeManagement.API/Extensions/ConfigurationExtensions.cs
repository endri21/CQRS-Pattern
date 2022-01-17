namespace EmployeeManagement.API.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");


    }
}
