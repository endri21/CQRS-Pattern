namespace XUnitTest.Services.Employee;

public class EmployeeTestsStartup : Startup
{

    public EmployeeTestsStartup(IConfiguration configuration) : base(configuration)
    {
    }

    protected override void ConfigureAuth(IApplicationBuilder app)
    {
        if (Configuration["isTest"] == bool.TrueString.ToLowerInvariant())
        {
            ///  app.UseMiddleware<AutoAuthorizeMiddleware>();
            app.UseAuthorization();
        }
        else
        {
            base.ConfigureAuth(app);
        }
    }
    ////public override IServiceProvider ConfigureServices(IServiceCollection services)
    ////{
    ////    // Added to avoid the Authorize data annotation in test environment. 
    ////    // Property "SuppressCheckForUnhandledSecurityMetadata" in appsettings.json

    ////    services.Configure<RouteOptions>(Configuration);
    ////    return base.ConfigureServices(services);
    ////}
}

