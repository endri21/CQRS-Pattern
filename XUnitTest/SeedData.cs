namespace XUnitTest
{
    public static class SeedData
    {

        public static readonly EmployeeModel emp1 = new EmployeeModel
        {
            firstName = "FN Employee 1",
            lastName = "LN Employee 1"
        };
        public static readonly EmployeeModel emp2 = new EmployeeModel
        {
            firstName = "FN Employee 2",
            lastName = "LN Employee 2"
        };
        public static readonly EmployeeModel emp3 = new EmployeeModel
        {
            firstName = "FN Employee 3",
            lastName = "LN Employee 3"
        };
        public static readonly EmployeeModel emp4 = new EmployeeModel
        {
            firstName = "FN Employee 4",
            lastName = "LN Employee 4"
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()/*, null*/))
            {

                if (dbContext._employees.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);


            }
        }
        public static void PopulateTestData(ApplicationDbContext dbContext)
        {
            ////foreach (var item in dbContext._employees)
            ////{
            ////    dbContext.Remove(item);
            ////}
            ////dbContext.SaveChanges();
            if (!dbContext._employees.Any())
            {
                dbContext._employees.Add(emp1);
                dbContext._employees.Add(emp2);
                dbContext._employees.Add(emp3);
                dbContext._employees.Add(emp4);

                dbContext.SaveChanges();
            }
        }


    }
}
