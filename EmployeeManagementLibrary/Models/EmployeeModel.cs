
namespace EmployeeManagementLibrary.Models
{
    public record EmployeeModel
    {
        public int id { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;

    }
}
