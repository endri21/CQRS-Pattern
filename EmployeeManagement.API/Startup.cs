using Autofac;
using Autofac.Extensions.DependencyInjection;
using EmployeeManagementLibrary;
using EmployeeManagementLibrary.Test;

namespace EmployeeManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc();
            services.AddScoped<ApplicationDbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var container = new ContainerBuilder();
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());

        }
        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }


}
