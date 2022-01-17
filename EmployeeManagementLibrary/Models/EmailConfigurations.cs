
namespace EmployeeManagementLibrary.Models
{
    public class EmailConfigurations
    {
        public string host { get; set; } = string.Empty;
        public int port { get; set; }
        public bool enableSSL { get; set; }
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

    }
}
