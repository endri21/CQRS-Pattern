using EmployeeManagementLibrary.Models;


namespace EmployeeManagementLibrary.Data;
public interface IDataAccess
{
    ///List<EmployeeDto> GetEmployees ();
    Task<IEnumerable<EmployeeModel>> GetEmployees();
    Task<EmployeeModel> GetEmployeeById(int id);
    Task<EmployeeModel> AddEmployee(string fname, string lname);
    Task<EmployeeModel> GetEmployeeByFName(string fName);

}

