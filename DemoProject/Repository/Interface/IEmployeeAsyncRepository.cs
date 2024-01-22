using DemoProject.Model;

namespace DemoProject.Repository.Interface
{
    public interface IEmployeeAsyncRepository
    {
        Task<Employee> GetEmployeeById(int Id);
        Task<List<Employee>> GetEmployeeByDepartmetnName(string DepartmentName);
        Task<List<Employee>> GetEmployeeBySalaryOrder();
        Task<long> AddNewEmployee(Employee employee);
        Task<long> UpdateEmployee(Employee employee);
        Task<long> DeleteEmployee(long Id);
        
    }
}
