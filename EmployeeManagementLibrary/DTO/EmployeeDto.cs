namespace EmployeeManagementLibrary.DTO
{
    public record EmployeeDto(EmployeeFNameDto EmployeeFName, EmployeeLNameDto EmployeeLName);
    public record EmployeeFNameDto(string fname);
    public record EmployeeLNameDto(string lname);



}

namespace EmployeeManagementLibrary.Test
{

    internal class TestInternalClass
    {
        internal void InternalMethod()
        {
            PublicMethod();
            Protected();
            // Method intentionally left empty.
        }
        public void PublicMethod()
        {
            InternalMethod();
            Protected();
            // Method intentionally left empty.
        }
        protected void Protected()
        {
            InternalMethod();
            // Method intentionally left empty.
        }
    }
    public class TestPublicClass
    {
        internal void InternalMethod()
        {
            TestInternalClass testInternal = new TestInternalClass();
            testInternal.InternalMethod();
            // Method intentionally left empty.
        }
        public void PublicMethod()
        {
            // Method intentionally left empty.
        }
        protected void Protected()
        {
            // Method intentionally left empty.
        }
    }
}
