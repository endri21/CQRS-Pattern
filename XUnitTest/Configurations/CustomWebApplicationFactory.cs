namespace XUnitTest.Configurations
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {


        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = builder.Build();
            builder.ConfigureWebHost(ConfigureWebHost);

            // Get service provider.
            var serviceProvider = host.Services;

            // Create a scope to obtain a reference to the database
            // context (AppDbContext).
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                var logger = scopedServices
                    .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
                // Ensure the database is created.
                try
                {
                    db.Database.EnsureCreated();
                    // Seed the database with test data.
                    SeedData.PopulateTestData(db);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the " +
                                        $"database with test messages. Error: {ex.Message}");
                }
            }

            host.Start();
            return host;
        }



        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureServices(services =>
                {
                    // Remove the app's ApplicationDbContext registration.
                    var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ApplicationDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }
                    // This should be set for each individual test run
                    ///string inMemoryCollectionName = Guid.NewGuid().ToString();

                    // Add ApplicationDbContext using an in-memory database for testing.
                    
                    services
                    .AddDbContext<ApplicationDbContext>(options =>
                     {
                     
                         /// options.UseInMemoryDatabase(inMemoryCollectionName);
                         options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Integrated Security=true;");
                     });
                });
        }
    }
}
