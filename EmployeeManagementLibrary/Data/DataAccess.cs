using EmployeeManagementLibrary.Models;

namespace EmployeeManagementLibrary.Data
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDataReadConnection _dataReadConnection;
        public DataAccess(ApplicationDbContext dbContext, IDataReadConnection dataReadConnection)
        {
            _dbContext = dbContext;
            _dataReadConnection = dataReadConnection;
        }

        public async Task<EmployeeModel> AddEmployee(string fname, string lname)
        {
            EmployeeModel addEmployee = new() { firstName = fname, lastName = lname };
            await _dbContext._employees.AddAsync(addEmployee);
            await _dbContext.SaveChangesAsync();
            return addEmployee;
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
             => await _dataReadConnection.QuerySingleAsync<EmployeeModel>(Get.GetEmployeeById(id));

        public async Task<EmployeeModel> GetEmployeeByFName(string fName)
           => await _dataReadConnection.QueryFirstOrDefaultAsync<EmployeeModel>(Get.GetEmployeeByFName(fName));

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
            => await _dataReadConnection.QueryAsync<EmployeeModel>(Get.GetEmployees);


        protected class Get
        {
            protected Get()
            {
            }
            public static string GetEmployees => "select * from _employees";
            public static string GetEmployeeById(int id) => $"select * from _employees as e where e.id= {id}";
            public static string GetEmployeeByFName(string fname) => $"select * from _employees where firstName like '%{fname}%'";
        }
    }
}
