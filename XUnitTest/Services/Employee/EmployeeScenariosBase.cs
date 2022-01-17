

namespace XUnitTest.Services.Employee
{
    public class EmployeeScenariosBase
    {
        private const string ApiUrlBase = "api/Employee";
        public TestServer CreateServer()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string? path = Assembly.GetAssembly(typeof(EmployeeUI))
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                .Location;

            var hostBuilder = new WebHostBuilder()
#pragma warning disable CS8604 // Possible null reference argument.
                .UseContentRoot(Path.GetDirectoryName(path))
#pragma warning restore CS8604 // Possible null reference argument.
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("Services/Employee/appsettings.json", optional: false)
                    .AddEnvironmentVariables();
                }).UseStartup<EmployeeTestsStartup>();

            return new TestServer(hostBuilder);
        }

        public static class Get
        {
            public static string GetEmployee(int id)
            {
                return $"{ApiUrlBase}/{id}";
            }

            public static string GetEmployeeByFName(string fname)
            {
                return $"{ApiUrlBase}/GetByName?{fname}";
            }
        }
        public static class Post
        {
            public static string CreateEmployee = $"{ApiUrlBase}/";
        }
    }
}
