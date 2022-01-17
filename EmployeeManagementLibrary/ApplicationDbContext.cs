using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeManagementLibrary
{
    public class ApplicationDbContext : DbContext
    {
        ///private readonly IMediator? _mediator;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

        : base(options)
        {
            /// _mediator = mediator;
        }

        ////protected ApplicationDbContext(DbContextOptions contextOptions)

        ////: base(contextOptions)
        ////{
        ////}

        public DbSet<Models.EmployeeModel> _employees { get; set; }
        public IDbConnection DbConnection => Database.GetDbConnection();

       
    }
}
